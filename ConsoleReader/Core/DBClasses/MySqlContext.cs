using Microsoft.EntityFrameworkCore;
using System.Configuration;
namespace ConsoleReader.Core.DBClasses
{
    class MySqlContext:DbContext
    {

        public DbSet<CityWeather> weatherItems { get; set; }
        public DbSet<City> cities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString);
        }
        
    }
}
