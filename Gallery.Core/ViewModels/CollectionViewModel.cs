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
            _cities.Add(new City("Image", "Some image", "louvre.jpg"));
            _cities.Add(new City("Image", "Some image", "louvre.jpg"));
            _cities.Add(new City("Image", "Some image", "louvre.jpg"));
            _cities.Add(new City("Image", "Some image", "louvre.jpg"));
            _cities.Add(new City("Image", "Some image", "louvre.jpg"));

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

    }
}
