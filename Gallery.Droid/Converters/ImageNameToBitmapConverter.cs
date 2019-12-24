using System;
using System.Globalization;
using Android.Graphics;
using MvvmCross;
using MvvmCross.Converters;
using MvvmCross.Platforms.Android;

namespace Gallery.Droid.Converters
{
    class ImageNameToBitmapConverter : MvxValueConverter<string, Bitmap>
    {
        protected override Bitmap Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            var topActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();

            var bm = BitmapFactory.DecodeResource(topActivity.Activity.Resources, GetResourceId(value, "drawable", topActivity));
            return bm;
        }
        private static int GetResourceId(string variableName, string resourceName, IMvxAndroidCurrentTopActivity topActivity)
        {
            try {
                return topActivity.Activity.Resources.GetIdentifier(variableName, resourceName, topActivity.Activity.PackageName);
            } catch(Exception) {
                return -1;
            }
        }
    }
}