using Microsoft.EntityFrameworkCore;
using System.Configuration;
namespace WeatherService
{
    class MySqlContext:DbContext
    {

        public DbSet<CityWeather> weatherItems { get; set; }
        public DbSet<City> cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString);
            // optionsBuilder.UseMySQL("server=localhost;port=3306;UserId=root;Password=root;database=weathersystem;Charset=utf8;");
        }
    }
}
