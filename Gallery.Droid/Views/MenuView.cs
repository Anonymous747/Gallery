using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Gallery.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace Gallery.Droid.Views
{
    [MvxFragmentPresentation(typeof(RootViewModel), Resource.Id.navigation_frame)]
    [Register(nameof(MenuFragment))]
    public class MenuFragment : MvxFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        private NavigationView _navigationView;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            view = this.BindingInflate(Resource.Layout.menu_view, null);

            _navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
            _navigationView.SetNavigationItemSelectedListener(this);
            _navigationView.Menu.FindItem(Resource.Id.nav_cities).SetChecked(true);

            var iconStartMenu = _navigationView.Menu.FindItem(Resource.Id.nav_menu);
            iconStartMenu.SetTitle("Start Menu");

            var iconCities = _navigationView.Menu.FindItem(Resource.Id.nav_cities);
            iconCities.SetTitle("Cities");

            var iconSetting = _navigationView.Menu.FindItem(Resource.Id.nav_setting);
            iconSetting.SetTitle("Setting");

            var iconHelp = _navigationView.Menu.FindItem(Resource.Id.nav_help);
            iconHelp.SetTitle("Help");

            return view;
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.nav_menu:
                    ViewModel.ShowMainPageCommand.Execute(null);
                    break;
                case Resource.Id.nav_cities:
                    ViewModel.ShowCollectionCommand.Execute(null);
                    break;
                case Resource.Id.nav_setting:
                    ViewModel.ShowSettingCommand.Execute(null);
                    break;
                case Resource.Id.nav_help:
                    ViewModel.ShowHelpCommand.Execute(null);
                    break;
            }

            ((RootActivity)Activity).DrawerLayout.CloseDrawers();
            return true;
        }
    }
}