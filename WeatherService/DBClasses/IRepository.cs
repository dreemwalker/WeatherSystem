using System.Collections.Generic;

namespace WeatherService
{
    interface IRepository
    {
        // IEnumerable<CityWeather> GetCities();
        List<CityWeatherViewModel> GetWeather();
       
    }
}
