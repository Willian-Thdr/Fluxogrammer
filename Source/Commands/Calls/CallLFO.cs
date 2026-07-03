using System.Diagnostics;
using System.IO;
using System.Windows;
using Fluxogrammer.Source;
using Microsoft.Win32;

public class CallFLO
{
    public static void Connect()
    {
        OpenFileDialog fileDialog = new();

        string path = Path.Combine(@"C:\Users\angel\OneDrive\Documents", "Fluxogramas", "DataCenter");

        fileDialog.InitialDirectory = path;
        fileDialog.Filter = "Fluxogramas (*.flux)|*.flux|Todos os arquivos (*.*)|*.*";


        if (fileDialog.ShowDialog() == true)
        {
            string way = fileDialog.FileName;

            Fluxreader.Connect(way);
        }
    }
}