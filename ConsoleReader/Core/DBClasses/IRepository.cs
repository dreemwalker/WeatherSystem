using System.Collections.Generic;

namespace ConsoleReader.Core.DBClasses
{
    interface IRepository<T> where T:class
    {
         void AddItems(IEnumerable<T> citiesWeather);
    }
}
