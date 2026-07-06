using System.Windows;

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
    }
}