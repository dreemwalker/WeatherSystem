using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleReader.Core;
using ConsoleReader.Core.Gismeteo;
using ConsoleReader.Core.DBClasses;
namespace ConsoleReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread myThread = new Thread(new ThreadStart(Run));
            //myThread.Start();
           
            Task mainTask = new Task(() =>Run());
            mainTask.Start();

            //if (!mainTask.IsCompleted)
            //{
            //    Console.WriteLine("Program will be closed after ending task");
            //}
           
            Console.ReadKey();
            Console.WriteLine("Program will be closed after ending task");
            mainTask.Wait();
           while(mainTask.Status!=TaskStatus.RanToCompletion)
            {

            }
            Console.WriteLine("Program will be closed after ending task");
            // Console.ReadKey();


        }
        public static async void Run( )
        {
          
                IParser<City> mainPageParser = new GismeteoMainPageParser();
                IParserSettings mainPageParserSettings = new GismeteoSettings();
                ParserWorker<City> mainPageWorker = new ParserWorker<City>(mainPageParserSettings, mainPageParser);
                IEnumerable<City> lst = await mainPageWorker.DoWork();

                CityRepository cityRepository = new CityRepository();
                cityRepository.AddItems(lst);

              

                IEnumerable<City> citiesinDb = cityRepository.GetItems();
                List<CityWeather> citiesWeather = new List<CityWeather>();
            foreach (City city in citiesinDb)
                {
                    IParser<CityWeather> weatherParser = new GismeteoWeatherPageParser(city);
                    IParserSettings weatherParserSettings = new GismeteoSettings();
                    weatherParserSettings.targetUrlPart = city.url;

                    ParserWorker<CityWeather> pageWorker = new ParserWorker<CityWeather>(weatherParserSettings, weatherParser);
                    IEnumerable<CityWeather> temp = await pageWorker.DoWork();
                
                    citiesWeather.AddRange(temp);

                }
            //  Thread.Sleep(1000);
            WeatherRepository repository = new WeatherRepository();
            repository.AddItems(citiesWeather);
            Console.WriteLine("OK");
        }
    }
}
