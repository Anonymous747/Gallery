using System.Threading.Tasks;
using MvvmCross.Navigation;
using Gallery.Core.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Gallery.Core.Services.Interfaces;

namespace Gallery.Core.ViewModels
{
    public class CollectionViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ICityServise _cityServise;

        public IMvxCommand<City> CitySelectedCommand { get; private set; }

        public CollectionViewModel(ICityServise cityServise,
            IMvxNavigationService navigationService)
        {
            _cityServise = cityServise;
            _navigationService = navigationService;

            Cities = new MvxObservableCollection<City>();
            CitySelectedCommand = new MvxAsyncCommand<City>(ImageSelected);

        }

        public override Task Initialize()
        {
            _cities = new MvxObservableCollection<City>();
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

        private async Task ImageSelected(City selectedPerson)
        {
            await _navigationService.Navigate<ImagePageViewModel, City>(selectedPerson);
        }
    }
}
