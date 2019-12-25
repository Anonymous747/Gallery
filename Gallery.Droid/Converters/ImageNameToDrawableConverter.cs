using System;
using System.Globalization;
using Android.Graphics;
using Android.Graphics.Drawables;
using MvvmCross;
using MvvmCross.Converters;
using MvvmCross.Platforms.Android;

namespace Gallery.Droid.Converters
{
    public class ImageNameToDrawableConverter : MvxValueConverter<string, Drawable>
    {
        protected override Drawable Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            var topActivity = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>();
            value = value.Replace(".jpg", "").Replace(".png", "");
            int id = (int)typeof(Resource.Drawable).GetField(value).GetValue(null);
            Drawable drawable = topActivity.Activity.Resources.GetDrawable(id);
            
            return drawable;
        }
    }
}