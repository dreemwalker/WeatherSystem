
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AngleSharp.Html.Dom;
using AngleSharp.Dom;
using System.Threading.Tasks;
namespace ConsoleReader.Core.Gismeteo
{
    class GismeteoMainPageParser : IParser<City>
    {
       
        private City GetCurrentCityUrl(IHtmlDocument document)
        {

            var currentCity = document.QuerySelectorAll("a").Where(item => item.ClassName != null &&item.ClassName == "link blue weather_current_link no_border");
         //   CityUrl cityUrl = new CityUrl(currentCity.First().TextContent, currentCity.First().GetAttribute("href"));
            string cityName = currentCity.First().TextContent;
            string cityUrl = currentCity.First().GetAttribute("href");

            City current = new City();
            current.name = cityName;
            current.url = cityUrl;
            return current;
        }
     

        public IEnumerable<City> Parse(IHtmlDocument document)
        {
            var list = new List<City>();
            list.Add(GetCurrentCityUrl(document));
            var items = document.QuerySelectorAll("#noscript a");

            foreach (var item in items)
            {
                string cityName= item.GetAttribute("data-name");
                if (list.FirstOrDefault(p => p.name == cityName) == null)
                {
                    City tempCity = new City();
                    tempCity.name = cityName;
                    tempCity.url = item.GetAttribute("href");
                    list.Add(tempCity);
                }
            }
           
            return list;
        }
    }
}
