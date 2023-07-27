namespace Battlefield1.UI.Converters;

public class StringToImageSourceConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string path = (string)value;
        if (string.IsNullOrWhiteSpace(path))
            return null;

        if (!path.StartsWith("http"))
            path = $"pack://application:,,,/Battlefield1;component{path}";

        return new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}