﻿using System.Collections.Generic;
using System.Reflection;
using Gallery.Core;
using Gallery.Core.Rest.Implementation;
using Gallery.Core.Rest.Intarface;
using Gallery.Core.Services.Interfaces;
using Gallery.Core.Services.Realisation;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters;
using MvvmCross.Plugin.Json;
using MvvmCross.ViewModels;

namespace Gallery.Droid
{
    public class Setup : MvxAppCompatSetup<App>
    {
        protected override IMvxApplication CreateApp()
        {
            Mvx.IoCProvider.RegisterType<IMvxJsonConverter, MvxJsonConverter>();
            Mvx.IoCProvider.RegisterType<IRestClient, RestClient>();
            Mvx.IoCProvider.RegisterType<ICityService, CityService>();
            return new App();
        }

        protected override IEnumerable<Assembly> AndroidViewAssemblies =>
        new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(Android.Support.Design.Widget.NavigationView).Assembly,
            typeof(Android.Support.Design.Widget.FloatingActionButton).Assembly,
            typeof(Android.Support.V7.Widget.Toolbar).Assembly,
            typeof(Android.Support.V4.Widget.DrawerLayout).Assembly,
            typeof(Android.Support.V4.View.ViewPager).Assembly,
            typeof(MvvmCross.Navigation.IMvxNavigationService).Assembly,
            typeof(MvvmCross.Droid.Support.V4.MvxFragment).Assembly
        };

        protected override IEnumerable<Assembly> ValueConverterAssemblies =>
            new List<Assembly>(base.ValueConverterAssemblies)
            {
                typeof(Gallery.Droid.Converters.ImageNameToBitmapConverter).Assembly,
                typeof(Gallery.Droid.Converters.ImageNameToDrawableConverter).Assembly
            };


        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            return new MvxAppCompatViewPresenter(AndroidViewAssemblies);
        }
    }
}