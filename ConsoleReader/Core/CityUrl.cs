using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReader.Core
{
    public class CityUrl
    {
        public string url { get; set; }
        public string name { get; set; }
        public CityUrl(string cityName, string cityUrl)
        {
            name = cityName;
            url = cityUrl;
        }
    }
}
