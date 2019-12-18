using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Navigation;
using Gallery.Core.Models;

namespace Gallery.Core.ViewModels
{
    public class CollectionViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public CollectionViewModel(
            IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            Cities = new List<City>();

        }

        public override Task Initialize()
        {
            _cities = new List<City>();
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

        private List<City> _cities;
        public List<City> Cities
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

        public async Task ImageSelected(City selectedPerson)
        {
            var result = await _navigationService.Navigate<ImagePageViewModel, City>(selectedPerson);
        }

        public async void OnItemClick(object sender, int position)
        {
            await ImageSelected(Cities[position]);
        }
    }
}
