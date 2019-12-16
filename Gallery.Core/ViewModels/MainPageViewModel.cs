using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Core.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MainPageViewModel(
            IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            ShowCollectionCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<CollectionViewModel>());
        }

        public IMvxCommand ShowCollectionCommand { get; private set; }
    }
}
