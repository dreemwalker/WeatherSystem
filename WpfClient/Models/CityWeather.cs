using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient.Models
{
    class CityWeather
    {
        public int id { get; set; }
        public string city { get; set; }
        public string value { get; set; }
        public string currentTemp { get; set; }
    }
}
