using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
namespace WpfClient.Models
{
    class JsonHttpClient
    {
        HttpClient client = new HttpClient();
        IClientSettings settings;
        public JsonHttpClient(IClientSettings clientSettings)
        {
            settings = clientSettings;
        }
        public async Task<List<City>> GetCitiesAsync()
        {
            List<City> cities= new List<City>();
            HttpResponseMessage response = await client.GetAsync(settings.baseUrl+ settings.getCityMethodName);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<List<City>>(data);
            }
            
            return cities;
        }
        public async Task<CityWeather> GetCityWeather( int cityId)
        {
            CityWeather city = new CityWeather();
            HttpResponseMessage response = await client.GetAsync(settings.baseUrl+settings.getCityWeatherMethodName+"/"+cityId);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                city = JsonConvert.DeserializeObject<CityWeather>(data);
            }
            return city;
        }

        public async Task<List<CityWeather>> GetWeatherAsync()
        {
            List<CityWeather> weatherItems = new List<CityWeather>();
            HttpResponseMessage response = await client.GetAsync(settings.baseUrl + settings.getWeatherMethodName);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                weatherItems = JsonConvert.DeserializeObject<List<CityWeather>>(data);
            }
            return weatherItems;
        }
    }   
}
