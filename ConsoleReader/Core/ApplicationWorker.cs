using ConsoleReader.Core.DBClasses;
using ConsoleReader.Core.Gismeteo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleReader.Core
{
    public class ApplicationWorker
    {
        private object locker = new object();
        private  List<CityWeather> citiesWeather;
        private UserActionsLocker exitLocker;
        public void Run()
        {
            exitLocker.Lock();
            UpdateCities();
            UpdateWeather();
            exitLocker.Unlock();
        }
        public ApplicationWorker(UserActionsLocker actionsLocker)
        {
            exitLocker = actionsLocker;
        }
        private async void UpdateCities()
        {
            ConsoleLogger.Log("Updating weather...");

            IParser<City> mainPageParser = new GismeteoMainPageParser();
            IParserSettings mainPageParserSettings = new GismeteoSettings();
            ParserWorker<City> mainPageWorker = new ParserWorker<City>(mainPageParserSettings, mainPageParser);
            ConsoleLogger.Log("Load cities...");

            IEnumerable<City> lst = await mainPageWorker.DoWork();

            CityRepository cityRepository = new CityRepository();

            ConsoleLogger.Log("Check cities...");
            cityRepository.AddItems(lst);
        }
        private async Task<IEnumerable<CityWeather>> LoadCityWeather(City city,int number)
        {
          
            IParser<CityWeather> weatherParser = new GismeteoWeatherPageParser(city);
            IParserSettings weatherParserSettings = new GismeteoSettings();
            weatherParserSettings.targetUrlPart = city.url;
            ParserWorker<CityWeather> pageWorker = new ParserWorker<CityWeather>(weatherParserSettings, weatherParser);
            IEnumerable<CityWeather> temp = await pageWorker.DoWork();

            lock (locker)
            {
                citiesWeather.AddRange(temp);
            }
            //ConsoleLogger.Log("CITY DONE "+number);
            return temp;
        }
        private  void StartLoadWeather(IEnumerable<City> cities)
        {
          
            List<Task> tasks = new List<Task>() ;
            int i = 0;
            foreach (City city in cities)
            {
                
                tasks.Add(Task.Run(() => LoadCityWeather(city,(0+i))));
                i++;
            }
            
            Task t = Task.WhenAll(tasks);
            t.Wait();
        }
        private void UpdateWeather()
        {

            CityRepository cityRepository = new CityRepository();
            IEnumerable<City> citiesinDb = cityRepository.GetItems();
             citiesWeather = new List<CityWeather>();

            ConsoleLogger.Log("Load weather...");

            StartLoadWeather(citiesinDb);

            WeatherRepository repository = new WeatherRepository();

            ConsoleLogger.Log("Saving weather...");
            repository.AddItems(citiesWeather);
            Console.WriteLine("Done");
        }
    }
}
