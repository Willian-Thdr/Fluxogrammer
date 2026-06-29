using System.Windows;

namespace Fluxogrammer.Source;
public partial class WindowError : Window
{
    public WindowError()
    {
        InitializeComponent();
    }

    public void Connect(String text)
    {
        ShowError.Text = text;
    }
}