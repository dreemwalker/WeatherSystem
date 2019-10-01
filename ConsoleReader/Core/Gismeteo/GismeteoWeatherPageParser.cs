using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;

namespace ConsoleReader.Core.Gismeteo
{
    class GismeteoWeatherPageParser : IParser<CityWeather>
    {
        private City _cityInfo;
        public GismeteoWeatherPageParser(City cityInfo)
        {
            _cityInfo = cityInfo;
        }

        public IEnumerable<CityWeather> Parse(IHtmlDocument document)
        {

            var weather = new List<CityWeather>();
            CityWeather temp = new CityWeather();
            var wholeTemperature = document.QuerySelectorAll("div.js_meas_container .unit_temperature_c .js_value").First().TextContent;
            //var fractionTemperature = document.QuerySelectorAll("div.js_meas_container .unit_temperature_c .tab-weather__value_m").First().TextContent;
            temp.currentTemp = wholeTemperature.Trim(' ','\n');
            temp.cityId = _cityInfo.Id;
            temp.date = DateTime.Now;
            weather.Add(temp);
            return weather;
        }
    }
}
