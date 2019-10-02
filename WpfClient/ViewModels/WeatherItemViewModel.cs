using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace WpfClient.ViewModels
{
    class WeatherItemViewModel : INotifyPropertyChanged
    {
        private string cityNameValue = string.Empty;
        private string temperatureValue = string.Empty;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string CityName
        {
            get
            {
                return this.cityNameValue;
            }

            set
            {
                if (value != this.cityNameValue)
                {
                    this.cityNameValue = value;
                    NotifyPropertyChanged();
                }
            }
        }
       
        public string Temperature
        {
            get
            {
                return this.temperatureValue;
            }

            set
            {
                if (value != this.temperatureValue)
                {
                    this.temperatureValue = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
