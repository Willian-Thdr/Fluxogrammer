using System.IO;
using System.Windows;

namespace Fluxogrammer.Source;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Console.WriteLine("Carregou");

        MenuButtonsActions.GetButtonNew(NewButton);
        MenuButtonsActions.GetButtonLoad(LoadButton);
    }

    public static void CreateBaseFlux(string? name)
    {
        string mainWay = AppDomain.CurrentDomain.BaseDirectory;
        string projWay = Directory.GetParent(mainWay).Parent.Parent.Parent.FullName;

        string fluxogramaFolder = Path.Combine(projWay, "Fluxogramas");
        string BkndFluxFolder = Path.Combine(fluxogramaFolder, "BkndFlux");

        Directory.CreateDirectory(BkndFluxFolder);

        File.SetAttributes(fluxogramaFolder, FileAttributes.Hidden);
        File.SetAttributes(BkndFluxFolder, FileAttributes.Hidden);

        string path = Path.Combine(BkndFluxFolder, name + ".xaml");
        
        File.WriteAllText(path, xamlCodeTemplate.codeTemplate(name));
    }
}