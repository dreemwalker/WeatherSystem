using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WeatherService;
namespace WeatherService
{
   
    public class Weather : IWeather
    {
        private WeatherRepository _repository;

        public Weather()
        {
            _repository = new WeatherRepository();
        }

        public List<CityViewModel> GetCities()
        {
          return  _repository.GetCityList();
        }

        public CityWeatherViewModel GetCityWeather(string id)
        {
           return _repository.GetWeatherByCityId(Convert.ToInt32(id));
        }

        public List<CityWeatherViewModel> GetWeather()
        {
            return _repository.GetWeather().ToList();
        }
     

    }
}
