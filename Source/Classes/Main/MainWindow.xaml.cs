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
}