using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReader.Core
{
    public class CityWeather
    {
        public int Id { get; set; }
        public int cityId { get; set; }
        public City city{ get; set; }
        public string currentTemp { get; set; }
        public DateTime date { get; set; }
    }
}
