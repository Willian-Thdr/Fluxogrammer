using System.Windows;
using Fluxogrammer.Source;

public class CallNFO
{
    public static void Connect()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            NewFileOptions secondWindow = new NewFileOptions();
            secondWindow.ShowDialog();
        });
    }
}