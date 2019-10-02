using System.Collections.Generic;

namespace ConsoleReader.Core.DBClasses
{
    class WeatherRepository:IRepository<CityWeather>
    {
        private MySqlContext db;
        public WeatherRepository()
        {
            db = new MySqlContext();
          //  db.Database.EnsureCreated(); в базе изменена кодировка 
        }
        public void AddItems(IEnumerable<CityWeather> citiesWeather)
        {
            db.weatherItems.AddRange(citiesWeather);
            db.SaveChanges();
        }
    }
}
