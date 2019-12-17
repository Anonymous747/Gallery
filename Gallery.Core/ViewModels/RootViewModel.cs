using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace Gallery.Core.ViewModels
{
    public class RootViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public RootViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowStartViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<MainPageViewModel>());
            ShowMenuViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<MenuViewModel>());
        }

        public IMvxAsyncCommand ShowStartViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowMenuViewModelCommand { get; private set; }
    }
}
