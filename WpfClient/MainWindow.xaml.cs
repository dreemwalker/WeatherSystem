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
       // List<CityViewModel> cities = new List<CityViewModel>();
        //List<WeatherViewModel> weatherItems = new List<WeatherViewModel>();
        WeatherWorker weatherWorker = new WeatherWorker();

        ObservableCollection<WeatherViewModel> weatherItemsObservable = new ObservableCollection<WeatherViewModel>();
        ObservableCollection<CityViewModel> citiesItemsObservable = new ObservableCollection<CityViewModel>();
        WeatherItemViewModel checkedCityWeather = new WeatherItemViewModel();
        public MainWindow()
        {
            InitializeComponent();
          
            GetCitiesAsync();
            GetWeatherAsync();

            weatherList.ItemsSource = weatherItemsObservable;
            citiesList.ItemsSource = citiesItemsObservable;
            citiesList.DisplayMemberPath = "name";
            citiesList.SelectedValuePath = "id";
            Binding binding = new Binding();
         
            //binding.ElementName = checkedCityWeather.Temperature; // элемент-источник
            //binding.Path = new PropertyPath(checkedCityWeather.Temperature); // свойство элемента-источника
            //CurrentCityWeather.SetBinding(TextBlock.TextProperty, binding); // установка привязки для элемента-приемника

        }
        async void GetCityWeatherById(int id)
        {
            
            WeatherViewModel cityWeather = await weatherWorker.GetCityWeather(id);
            checkedCityWeather.CityName = cityWeather.city;
            checkedCityWeather.Temperature = cityWeather.value;
            CurrentCityWeather.Text = cityWeather.city+"  "+ cityWeather.value; 

        }
        async void GetWeatherAsync()
        {
            weatherItemsObservable.Clear();
            List<WeatherViewModel> weatherItems   = await weatherWorker.GetAllWeatherItems();
           
            foreach (WeatherViewModel item in weatherItems) {
                weatherItemsObservable.Add(item);
            }
            
        }
        async  void GetCitiesAsync()
        {
            List<CityViewModel> cities   = await weatherWorker.GetCitiesAsync();
            foreach(CityViewModel city in cities)
            {
                citiesItemsObservable.Add(city);
            }
        }

        private void CitiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetCityWeatherById((int)citiesList.SelectedValue);
        }
    }
}
