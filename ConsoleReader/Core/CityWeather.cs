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
        public string CityName{ get; set; }
        public string CurrentTemp { get; set; }
        public DateTime Date { get; set; }
    }
}
