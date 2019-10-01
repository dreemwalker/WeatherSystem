using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace WeatherService
{
    class WeatherRepository:IRepository
    {
        private MySqlContext db;
        public WeatherRepository()
        {
            db = new MySqlContext();
          //  db.Database.EnsureCreated(); в базе изменена кодировка 
        }
        public List<CityViewModel> GetCityList()
        {
            List<CityViewModel> viewModel = new List<CityViewModel>();

            foreach(City city in db.cities)
            {
                viewModel.Add(new CityViewModel {
                    Id = city.Id,
                    name = city.name
                });
            }
            return viewModel;
        }
        public CityWeatherViewModel GetWeatherByCityId(int id)
        {
            var city = db.cities.FirstOrDefault(c => c.Id == id);
            var weatherItem = db.weatherItems.Where(c => c.cityId == id).OrderByDescending(d=>d.Date).First();

            CityWeatherViewModel vmItem = new CityWeatherViewModel
            {
                Id = weatherItem.Id,
                city = city.name,
                CurrentTemp = weatherItem.CurrentTemp,
                Date = weatherItem.Date
            };
           return vmItem;
        }
       
        public List<CityWeatherViewModel> GetWeather()
        {
            //SELECT w.Id ,c.name, w.currentTemp, w.date
            //  FROM weathersystem.weatheritems w
            //  JOIN weathersystem.cities c on(w.cityId = c.Id)
            //  WHERE(cityId, date)
            //  in(
            //    SELECT cityId, MAX(date)
            //      FROM weathersystem.weatheritems
            //      GROUP BY cityId
            //  )
        
            List<CityWeatherViewModel> vm = new List<CityWeatherViewModel>();

            var weatherItems = db.weatherItems
                .GroupBy(t => t.cityId)
                .Select(ig => ig.OrderByDescending(t => t.Date).First()).ToList();

            foreach (CityWeather weatherItem in weatherItems)
            {
                var city = db.cities.FirstOrDefault(c => c.Id == weatherItem.cityId);
                CityWeatherViewModel vmItem = new CityWeatherViewModel
                {
                    Id = weatherItem.Id,
                    city = city.name,
                    CurrentTemp = weatherItem.CurrentTemp,
                    Date = weatherItem.Date
                };
                vm.Add(vmItem);
            }
            

            return vm;
        }
    }
}
