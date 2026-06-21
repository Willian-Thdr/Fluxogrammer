using System.IO;
using System.Windows;

namespace Fluxogrammer.Source;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Console.WriteLine("Carregou");

        CreateBaseFlux();
        MenuButtonsActions.GetButtonNew(NewButton);
        MenuButtonsActions.GetButtonLoad(LoadButton);
    }

    private void CreateBaseFlux()
    {
        string mainWay = "C:/Users/angel";

        string fluxogramaFolder = Path.Combine(mainWay, "Fluxogramas");
        string BkndFluxFolder = Path.Combine(fluxogramaFolder, "BkndFlux");

        Directory.CreateDirectory(BkndFluxFolder);

        File.SetAttributes(fluxogramaFolder, FileAttributes.Hidden);
        File.SetAttributes(BkndFluxFolder, FileAttributes.Hidden);

        string path = Path.Combine(BkndFluxFolder, "fluxograma.xaml");
        File.WriteAllText(path, xamlCodeTemplate.codeTemplate());
    }
}