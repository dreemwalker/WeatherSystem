﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace WpfClient.Models
{
    class JsonHttpClientSettings: IClientSettings
    {
        public string baseUrl { get; set; } = ConfigurationSettings.AppSettings.Get("ServiceBaseUrl");
        public string getCityMethodName { get; set; } = "GetCities";
        public string getWeatherMethodName { get; set; } = "GetWeather";
        public string getCityWeatherMethodName { get; set; } = "GetCityWeather";
    }
}
