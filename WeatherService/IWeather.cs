using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WeatherService
{
 
    [ServiceContract]
    public interface IWeather
    {

        [WebGet(UriTemplate = "/GetWeather",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        List<CityWeatherViewModel> GetWeather();

        [WebGet(UriTemplate = "/GetCities",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        List<CityViewModel> GetCities();

        [WebGet(UriTemplate = "/GetCityWeather/{id}",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        CityWeatherViewModel GetCityWeather(string id);
    }
    [DataContract]
    public class CityWeather
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int cityId { get; set; }
        [DataMember]
        public string CurrentTemp { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public City city { get; set; }

       
    }
    [DataContract]
    public class CityViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class CityWeatherViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public string CurrentTemp { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
    }
    [DataContract]
    public class City
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string name { get; set; }
    }

  



}
