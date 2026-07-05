using System.Globalization;
using System.Windows.Data;

namespace Fluxogrammer.Source;
public class BindingDivide : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        double actualValue = (double)value;
        double divisor = double.Parse(parameter.ToString(), CultureInfo.InvariantCulture);
        return actualValue / divisor;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}