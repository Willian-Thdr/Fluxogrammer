using System.IO;
using System.Windows;
using Fluxogrammer.Source;
using Microsoft.Win32;

public class ColorFont
{
    private static ResourceDictionary? _dicAtual;
    public static void Change(string? tema)
    {
        string CaminhoTema = tema switch
        {
            "Padrão" => "Source/Style/Default.xaml",
            "Claro" => "Source/Style/TemaClaro.xaml",
            "Escuro" => "Source/Style/TemaEscuro.xaml",
            _ => "Source/Style/Default.xaml"
        };

        var dict = new ResourceDictionary
        {
            Source = new Uri(CaminhoTema, UriKind.Relative)
        };

        if (_dicAtual != null)
            Application.Current.Resources.MergedDictionaries.Remove(_dicAtual);

        Application.Current.Resources.MergedDictionaries.Add(dict);
        _dicAtual = dict;

        SaveTheme(tema);
        OptionsWindow.nameLabel = tema;
    }

    private static void SaveTheme(string tema)
    {
        string way = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        string fileName = "config.fluxcfg";
        string configFolder = Path.Combine(way, "Fluxogramas");
        string finalWay = Path.Combine(configFolder, ".config");
        string path = Path.Combine(finalWay, fileName);

        Directory.CreateDirectory(configFolder);
        Directory.CreateDirectory(finalWay);

        File.SetAttributes(finalWay, File.GetAttributes(finalWay) | FileAttributes.Hidden);

        if (File.Exists(path))
        {
            File.SetAttributes(path, FileAttributes.Normal);
        }

        File.WriteAllText(path, FluxcfgConverter.WriteConfig(tema));

        File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
    }
}