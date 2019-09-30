using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ConsoleReader.Core.DBClasses
{
    class MySqlContext:DbContext
    {

        public DbSet<CityWeather> weatherItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306;UserId=root;Password=root;database=weathersystem;Charset=utf8;");
        }
    }
}
