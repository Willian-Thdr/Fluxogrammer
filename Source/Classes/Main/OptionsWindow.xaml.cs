using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Fluxogrammer.Source;
public partial class OptionsWindow : Window
{
    private static Label label;
    private static Popup popup;

    public OptionsWindow()
    {
        InitializeComponent();
        label = TemaEscolhido;
        popup = PopupTheme;
    }

    private void ThemeButtonClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        string? nameButton = button.Content.ToString();

        TemaEscolhido.Content = button.Content;
        ColorFont.Change(nameButton);
        PopupTheme.IsOpen = false;
    }
}