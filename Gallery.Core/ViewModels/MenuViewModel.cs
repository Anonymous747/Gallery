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

            ShowStartCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<StartViewModel>());
            ShowCollectionCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<CollectionViewModel>());
        }

        public IMvxCommand ShowStartCommand { get; private set; }
        public IMvxCommand ShowCollectionCommand { get; private set; }
    }
}
