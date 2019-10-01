using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfClient.ViewModels;
using WpfClient.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
namespace WpfClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CityViewModel> cities = new List<CityViewModel>();
        List<WeatherViewModel> weatherItems = new List<WeatherViewModel>();
        WeatherWorker weatherWorker = new WeatherWorker();
        ObservableCollection<WeatherViewModel> weatherItemsObservable = new ObservableCollection<WeatherViewModel>();
        public MainWindow()
        {
            InitializeComponent();
          
            GetCitiesAsync();
            GetWeather();
            weatherList.ItemsSource = weatherItemsObservable;

        }
        async void GetCityWeatherById(int id)
        {
            weatherItems = new List<WeatherViewModel>();
            WeatherViewModel weatherItem = await weatherWorker.GetCityWeather(id);
            weatherItems.Add(weatherItem);
        }
        async void GetWeather()
        {
            weatherItems = await weatherWorker.GetAllWeatherItems();
            weatherItemsObservable.Clear();
            foreach (WeatherViewModel item in weatherItems) {
                weatherItemsObservable.Add(item);
            }
            
        }
        async  void GetCitiesAsync()
        {
            cities = await weatherWorker.GetCitiesAsync();
        }

        private void CitiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
