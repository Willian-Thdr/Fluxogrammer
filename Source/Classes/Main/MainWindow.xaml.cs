using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Fluxogrammer.Source;
public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();

        MenuButtonsActions.GetButtonNew(NewButton);
        MenuButtonsActions.GetButtonLoad(LoadButton);

        CreateArchives();
        Check();

        OpenConfig.Click += (s, e) =>
        {
            OptionsWindow options = new();
            options.Show();
        };
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

    public static void CreateArchives()
    {
        string mainWay = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        string fluxogramaFolder = Path.Combine(mainWay, "Fluxogramas");
        string DataCenter = Path.Combine(fluxogramaFolder, "DataCenter");

        string Backup = Path.Combine(fluxogramaFolder, "Backup");
        string Config = Path.Combine(fluxogramaFolder, ".config");
        string path = Path.Combine(Config, "config.fluxcfg");

        Directory.CreateDirectory(DataCenter);
        Directory.CreateDirectory(Backup);
        Directory.CreateDirectory(Config);

        if (!File.Exists(path))
        {
            ColorFont.Change("Padrão");
        }

        File.SetAttributes(Backup, File.GetAttributes(Backup) | FileAttributes.Hidden);
        File.SetAttributes(Config, File.GetAttributes(Config) | FileAttributes.Hidden);

        ReadConfig(Config);
    }

    public static void ReadConfig(string configWay)
    {
        string[] archive = Directory.GetFiles(configWay);
        string archiveName;

        foreach (string levels in archive)
        {
            archiveName = Path.GetFileName(levels);
            string path = Path.Combine(configWay, archiveName);

            FluxcfgReader.Connect(path);
        }
    }
}