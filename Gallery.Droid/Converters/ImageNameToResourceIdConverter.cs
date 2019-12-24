using System;
using System.Globalization;
using MvvmCross.Converters;

namespace Gallery.Droid.Converters
{
    class ImageNameToResourceIdConverter : MvxValueConverter<string, int>
    {
        protected override int Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            value = value.Replace(".jpg", "").Replace(".png", "");
            return (int)typeof(Resource.Drawable).GetField(value).GetValue(null);
        }
        
    }
}