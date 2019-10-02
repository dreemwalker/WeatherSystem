using System.Collections.Generic;
using System.Linq;

namespace ConsoleReader.Core.DBClasses
{
    class CityRepository:IRepository<City>
    {
        private MySqlContext db;
        public CityRepository()
        {
            db = new MySqlContext();
            // db.Database.EnsureCreated(); //в базе изменена кодировка 
         

        }
        public void AddItems(IEnumerable<City> cities)
        {
            foreach(City city in cities)
            {

                var contains = db.cities.FirstOrDefault(item => item.url == city.url);
                if (contains==null)
                {
                    db.cities.Add(city);
                   
                }
            }
            db.SaveChanges();

        }
        public IEnumerable<City> GetItems()
        {
            return db.cities.ToList();
        }
    }
}
