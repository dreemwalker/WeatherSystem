using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReader.Core.DBClasses
{
    interface IRepository
    {
         void AddWeatherList(IEnumerable<CityWeather> citiesWeather);
    }
}
