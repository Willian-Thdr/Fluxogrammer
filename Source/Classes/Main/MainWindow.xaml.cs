using System.Diagnostics;
using System.Windows;

namespace Fluxogrammer.Source;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        MenuButtonsActions.GetButtonNew(NewButton);
        MenuButtonsActions.GetButtonLoad(LoadButton);

        Check();
    }

    public async void Check()
    {
        string actualVersion = "v0.1-beta.6";
        string? lastVersion = await VersionChecker.GetLastVersion();
    
        if (lastVersion != actualVersion && lastVersion != null)
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

    public void ChangeBackground(object color)
    {
        this.Background = (System.Windows.Media.Brush)color;
    }
}