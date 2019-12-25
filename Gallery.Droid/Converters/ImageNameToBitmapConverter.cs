using System;
using System.Globalization;
using Android.Graphics;
using Android.Graphics.Drawables;
using MvvmCross;
using MvvmCross.Converters;
using MvvmCross.Platforms.Android;

namespace Gallery.Droid.Converters
{
    public class ImageNameToBitmapConverter : MvxValueConverter<string, Drawable>
    {
        protected override Drawable Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            var topActivity = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>();
            value = value.Replace(".jpg", "").Replace(".png", "");
            int id = GetResourceId(value, "drawable", topActivity);
            Drawable drawable = topActivity.Activity.Resources.GetDrawable(id);
            return drawable;
        }
        private static int GetResourceId(string variableName, string resourceName, IMvxAndroidCurrentTopActivity topActivity)
        {
            try {
                var t = topActivity.Activity.Resources.GetIdentifier(variableName, resourceName, topActivity.Activity.PackageName);
                return t;
            } catch(Exception) {
                return -1;
            }
        }
    }
}