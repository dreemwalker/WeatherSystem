using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReader.Core.DBClasses
{
    class WeatherRepository:IRepository
    {
        private MySqlContext db;
        public WeatherRepository()
        {
            db = new MySqlContext();
          //  db.Database.EnsureCreated(); в базе изменена кодировка 
        }
        public void AddWeatherList(IEnumerable<CityWeather> citiesWeather)
        {
            db.weatherItems.AddRange(citiesWeather);
            db.SaveChanges();
        }
    }
}
