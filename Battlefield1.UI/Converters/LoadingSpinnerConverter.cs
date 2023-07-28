namespace Battlefield1.UI.Converters;

public class LoadingSpinnerConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length < 2 || 
            !double.TryParse(values[0].ToString(), out double diameter) || 
            !double.TryParse(values[1].ToString(), out double thickness))
        {
            return new DoubleCollection(new[] { 0.0 });
        }

        var circumference = Math.PI * diameter;

        var lineLength = circumference * 0.75;
        var gapLength = circumference - lineLength;

        return new DoubleCollection(new[] { lineLength / thickness, gapLength / thickness });
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        return null;
    }
}