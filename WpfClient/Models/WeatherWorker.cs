using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfClient.ViewModels;
namespace WpfClient.Models
{
    class WeatherWorker
    {
        JsonHttpClient client;
        
        public WeatherWorker()
        {
            IClientSettings settings = new JsonHttpClientSettings();
            client = new JsonHttpClient(settings);
        }
        public async Task<List<CityViewModel>> GetCitiesAsync()
        {
            List<CityViewModel> vmCityList = new List<CityViewModel>();
            var cities = await client.GetCitiesAsync();
            foreach (var city in cities)
            {
                CityViewModel tempCityVm = new CityViewModel()
                {
                    id = city.id,
                    name = city.name
                };
                vmCityList.Add(tempCityVm);
            }
            return vmCityList;
        }
        public async Task<WeatherViewModel> GetCityWeather(int cityId)
        {
           
            var cityWeather = await client.GetCityWeather(cityId);
          
            WeatherViewModel tempWeatherVm = new WeatherViewModel()
            {
                city = cityWeather.city,
                value = cityWeather.currentTemp
            };

            return tempWeatherVm;
        }
        public async Task<List<WeatherViewModel>> GetAllWeatherItems()
        {
            List<WeatherViewModel> weatherViewModelItems = new List<WeatherViewModel>();
            var weather = await client.GetWeatherAsync();
            foreach (var weatherItem in weather)
            {
                WeatherViewModel tempWeatherVm = new WeatherViewModel()
                {
                    city=weatherItem.city,
                    value=weatherItem.currentTemp
                };
                weatherViewModelItems.Add(tempWeatherVm);
            }
            return weatherViewModelItems;
        }
    }
}
