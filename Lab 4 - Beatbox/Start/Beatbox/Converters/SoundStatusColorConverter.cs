using System;
using System.Globalization;
using Xamarin.Forms;

namespace Beatbox.Converters
{
    public class SoundStatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is SoundStatus)) return value;

            var status = (SoundStatus)value;
            switch (status)
            {
                case SoundStatus.Empty:
                    return Color.LightGray;
                case SoundStatus.Idle:
                case SoundStatus.Busy:
                    return Color.Gray;
                case SoundStatus.Recording:
                    return Color.Red;
                case SoundStatus.Playing:
                    return Color.Green;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}