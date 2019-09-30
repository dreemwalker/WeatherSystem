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
          
                IParser<CityUrl> mainPageParser = new GismeteoMainPageParser();
                IParserSettings mainPageParserSettings = new GismeteoSettings();

                ParserWorker<CityUrl> mainPageWorker = new ParserWorker<CityUrl>(mainPageParserSettings, mainPageParser);
                IEnumerable<CityUrl> lst = await mainPageWorker.DoWork();


                List<CityWeather> citiesWeather = new List<CityWeather>();
                foreach (CityUrl item in lst)
                {
                    IParser<CityWeather> weatherParser = new GismeteoWeatherPageParser(item);
                    IParserSettings weatherParserSettings = new GismeteoSettings();
                    weatherParserSettings.targetUrlPart = item.url;

                    ParserWorker<CityWeather> pageWorker = new ParserWorker<CityWeather>(weatherParserSettings, weatherParser);
                    IEnumerable<CityWeather> temp = await pageWorker.DoWork();
                    citiesWeather.AddRange(temp);

                }
            //  Thread.Sleep(1000);
            WeatherRepository repository = new WeatherRepository();
            repository.AddWeatherList(citiesWeather);
            Console.WriteLine("OK");
        }
    }
}
