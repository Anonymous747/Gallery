using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Gallery.Core.Models;
using MvvmCross.ViewModels;

namespace Gallery.Core.ViewModels
{
    public class CitiesViewModel : BaseViewModel
    {
        public CitiesViewModel()
        {
            _cities = new MvxObservableCollection<City>();
        }
        public override Task Initialize()
        {
            _cities.Add(new City("Germany", "Some information about it", "Germany.jpg"));
            _cities.Add(new City("Japan", "Some information about it", "Japan.jpg"));
            _cities.Add(new City("New York", "Some information about it", "NewYouk.jpg"));
            _cities.Add(new City("Germany", "Some information about it", "Germany.jpg"));
            _cities.Add(new City("Japan", "Some information about it", "Japan.jpg"));
            _cities.Add(new City("New York", "Some information about it", "NewYouk.jpg"));
            _cities.Add(new City("Germany", "Some information about it", "Germany.jpg"));
            _cities.Add(new City("Japan", "Some information about it", "Japan.jpg"));
            _cities.Add(new City("New York", "Some information about it", "NewYouk.jpg"));

            return base.Initialize();
        }

        private MvxObservableCollection<City> _cities;
        public MvxObservableCollection<City> Cities
        {
            get
            {
                return _cities;
            }
            set
            {
                _cities = value;
                RaisePropertyChanged(() => Cities);
            }
        }
    }
}
