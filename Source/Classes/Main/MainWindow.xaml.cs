using System.Diagnostics;
using System.Windows;

namespace Fluxogrammer.Source;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        Check();
        InitializeComponent();

        MenuButtonsActions.GetButtonNew(NewButton);
        MenuButtonsActions.GetButtonLoad(LoadButton);
    }

    public async void Check()
    {
        string actualVersion = "v0.1-beta.6";
        string? lastVersion = await VersionChecker.GetLastVersion();
    
        if (lastVersion != actualVersion)
        {
            MessageBoxResult resultado = MessageBox.Show(
                $"Uma nova versão está disponível: {lastVersion}\nDeseja baixar agora?",
                "Atualização disponível",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information
            );

            if (resultado == MessageBoxResult.Yes)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/Willian-Thdr/Fluxogrammer/releases/latest",
                    UseShellExecute = true
                });
            }
        }
    }
}