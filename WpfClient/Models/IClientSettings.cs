namespace WpfClient.Models
{
    interface IClientSettings
    {
        string baseUrl { get; set; }
        string getCityMethodName { get; set; }
        string getWeatherMethodName { get; set; }
        string getCityWeatherMethodName { get; set; }
    }
}
