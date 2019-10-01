using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient.Models
{
    interface IClientSettings
    {
        string baseUrl { get; set; }
        string getCityMethodName { get; set; }
        string getWeatherMethodName { get; set; }
        string getCityWeatherMethodName { get; set; }
    }
}
