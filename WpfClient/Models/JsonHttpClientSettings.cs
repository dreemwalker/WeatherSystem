using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient.Models
{
    class JsonHttpClientSettings: IClientSettings
    {
        public string baseUrl { get; set; } = "http://localhost:25477/Weather.svc/";
        public string getCityMethodName { get; set; } = "GetCities";
        public string getWeatherMethodName { get; set; } = "GetWeather";
        public string getCityWeatherMethodName { get; set; } = "GetCityWeather";
    }
}
