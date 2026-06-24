using System.Windows;
using Fluxogrammer.Source;

public class CallNFO
{
    public static void Connect()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            NewFileOptions secondWindow = new NewFileOptions();
            Console.WriteLine("Chegou ao Call");

            secondWindow.ShowDialog();
        });
    }
}