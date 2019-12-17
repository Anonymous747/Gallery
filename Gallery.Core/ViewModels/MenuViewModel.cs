using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowMainPageCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<MainPageViewModel>());
            ShowCollectionCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<CollectionViewModel>());
            ShowSettingCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<SettingViewModel>());
            ShowHelpCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<HelpViewModel>());
        }

        public IMvxCommand ShowMainPageCommand { get; private set; }
        public IMvxCommand ShowCollectionCommand { get; private set; }
        public IMvxCommand ShowSettingCommand { get; private set; }
        public IMvxCommand ShowHelpCommand { get; private set; }
    }
}
