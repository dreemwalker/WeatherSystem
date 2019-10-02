using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleReader.Core;
using ConsoleReader.Core.Gismeteo;
using ConsoleReader.Core.DBClasses;
using System.Timers;
namespace ConsoleReader
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        private static bool locker=false;
        static void Main(string[] args)
        {
            SetTimer();
            while (true)
            {
                Console.ReadLine();
                if (!locker)
                {
                   
                    aTimer.Stop();
                    aTimer.Dispose();
                    ConsoleLogger.Log("Terminating the application...");
                  
                    break;
                }
                else
                {
                    ConsoleLogger.Log("Please wait for weather update...");
                }
            }

        }
        private static void SetTimer()
        {
            Run();
            aTimer = new System.Timers.Timer(300000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            aTimer.Start();
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Run();
        }
      
        public static async void Run( )
        {
            locker = true;

            ConsoleLogger.Log("Updating weather...");

            IParser<City> mainPageParser = new GismeteoMainPageParser();
            IParserSettings mainPageParserSettings = new GismeteoSettings();
            ParserWorker<City> mainPageWorker = new ParserWorker<City>(mainPageParserSettings, mainPageParser);
            ConsoleLogger.Log("Load cities...");

            IEnumerable<City> lst = await mainPageWorker.DoWork();

            CityRepository cityRepository = new CityRepository();

            ConsoleLogger.Log("Check cities...");
            cityRepository.AddItems(lst);
            
            IEnumerable<City> citiesinDb = cityRepository.GetItems();
            List<CityWeather> citiesWeather = new List<CityWeather>();

            ConsoleLogger.Log("Load weather...");
            foreach (City city in citiesinDb)
                {
                    IParser<CityWeather> weatherParser = new GismeteoWeatherPageParser(city);
                    IParserSettings weatherParserSettings = new GismeteoSettings();
                    weatherParserSettings.targetUrlPart = city.url;

                    ParserWorker<CityWeather> pageWorker = new ParserWorker<CityWeather>(weatherParserSettings, weatherParser);
                    IEnumerable<CityWeather> temp =await  pageWorker.DoWork();
                
                    citiesWeather.AddRange(temp);

                }
         
            WeatherRepository repository = new WeatherRepository();

            ConsoleLogger.Log("Saving weather...");
            repository.AddItems(citiesWeather);
            Console.WriteLine("Done");
            locker = false;
        }
    }
}
