using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;

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
                if (document != null)
                {
                    //current/tomorrow temperature
                    var wholeTemperature = document.QuerySelectorAll("div.js_meas_container .unit_temperature_c .js_value").First().TextContent;//current
                                                                                                                                                //var wholeTemperature = document.QuerySelectorAll("a.nolink  .unit_temperature_c").Last().TextContent;//tomorrow

                    temp.currentTemp = wholeTemperature.Trim(' ', '\n');
                    temp.cityId = _cityInfo.Id;
                    temp.date = DateTime.Now;
                    weather.Add(temp);
                }
                else
                {
                    ConsoleLogger.Error("Empty document", this);
                }
            
            return weather;
        }
    }
}
