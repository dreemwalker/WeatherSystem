
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AngleSharp.Html.Dom;
using AngleSharp.Dom;
using System.Threading.Tasks;
namespace ConsoleReader.Core.Gismeteo
{
    class GismeteoMainPageParser : IParser<CityUrl>
    {
       
        private CityUrl GetCurrentCityUrl(IHtmlDocument document)
        {

            var currentCity = document.QuerySelectorAll("a").Where(item => item.ClassName != null &&item.ClassName == "link blue weather_current_link no_border");
         //   CityUrl cityUrl = new CityUrl(currentCity.First().TextContent, currentCity.First().GetAttribute("href"));
            string cityName = currentCity.First().TextContent;
            string cityUrl = currentCity.First().GetAttribute("href");
            return new CityUrl(cityName,cityUrl) ;
        }
     

        public IEnumerable<CityUrl> Parse(IHtmlDocument document)
        {
            var list = new List<CityUrl>();
            list.Add(GetCurrentCityUrl(document));

          
            var items = document.QuerySelectorAll("#noscript a");

            //var hrefList = divContent.Descendents().Where(tag => tag.NodeName == "div");

            foreach (var item in items)
            {
                list.Add(new CityUrl(item.GetAttribute("data-name"),  item.GetAttribute("href")));
            }
            return list;
        }
    }
}
