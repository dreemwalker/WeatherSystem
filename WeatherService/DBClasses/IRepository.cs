using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService
{
    interface IRepository
    {
        // IEnumerable<CityWeather> GetCities();
        List<CityWeatherViewModel> GetWeather();
       
    }
}
