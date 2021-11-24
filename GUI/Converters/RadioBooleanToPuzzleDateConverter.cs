using System;
using System.Globalization;
using System.Windows.Data;
using GUI.Constants;

namespace GUI.Converters
{
    public class RadioBooleanToPuzzleDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                PuzzleDays days => days == (PuzzleDays) parameter,
                PuzzleYears years => years == (PuzzleYears) parameter,
                _ => false
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? parameter : Binding.DoNothing;
        }
    }
}
