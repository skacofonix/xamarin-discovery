using System;
using System.Globalization;
using Xamarin.Forms;

namespace Beatbox.Converters
{
    public class SoundStatusTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is SoundStatus)) return value;

            var status = (SoundStatus)value;
            switch (status)
            {
                case SoundStatus.Empty:
                    return string.Empty;
                    break;
                case SoundStatus.Idle:
                    return "Ilde";
                    break;
                case SoundStatus.Busy:
                    return "Busy";
                    break;
                case SoundStatus.Recording:
                    return "Rec";
                    break;
                case SoundStatus.Playing:
                    return "Play";
                    break;
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