using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReader.Core.DBClasses
{
    interface IRepository<T> where T:class
    {
         void AddItems(IEnumerable<T> citiesWeather);
    }
}
