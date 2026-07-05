using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Fluxogrammer.Source;
public partial class OptionsWindow : Window
{
    MainWindow window = new();

    public OptionsWindow()
    {
        InitializeComponent();
    }

    private void ThemeButtonClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        string? corHex = button.Tag.ToString();

        if (corHex == "NaN")
        {
            var newColor = new LinearGradientBrush();
            newColor.StartPoint = new Point(0, 0);
            newColor.EndPoint = new Point(1, 1);
            newColor.GradientStops.Add(new GradientStop(Color.FromRgb(91, 16, 148), 0));
            newColor.GradientStops.Add(new GradientStop(Color.FromRgb(112, 138, 239), 1));

            window.Background = newColor;
            this.Background = newColor;

            TemaEscolhido.Content = button.Content;
            PopupTheme.IsOpen = false;
        }
        else
        {
            var newColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(corHex));
            window.Background = newColor;            
            this.Background = newColor;

            TemaEscolhido.Content = button.Content;
            PopupTheme.IsOpen = false;
        }
    }
}