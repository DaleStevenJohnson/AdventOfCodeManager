using System;
using System.Globalization;
using System.Windows.Data;
using GUI.Constants;

namespace GUI.Converters
{
    public class RadioBooleanToPuzzleDayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((PuzzleDays)value == (PuzzleDays)parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? parameter : Binding.DoNothing;
        }
    }
}
