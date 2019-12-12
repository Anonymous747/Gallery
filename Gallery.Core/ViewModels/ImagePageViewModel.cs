using Gallery.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace Gallery.Core.ViewModels
{
    public class ImagePageViewModel : BaseViewModel<City>
    {
        private readonly IMvxNavigationService _navigationService;
        public IMvxCommand CLoseImageCommand { get; private set; }
        public ImagePageViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            CLoseImageCommand = new MvxAsyncCommand(async () => await _navigationService.Close(this));
        }


        public override void Prepare(City parameter)
        {
            City = parameter;
        }
        private City _city;
        public City City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                RaisePropertyChanged(() => City);
            }
        }
    }
}
