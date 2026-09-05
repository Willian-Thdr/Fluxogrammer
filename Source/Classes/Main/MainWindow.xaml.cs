using System.Diagnostics;
using System.Windows.Media;
using System.IO;
using System.Security.Cryptography;
using System.Windows;

namespace Fluxogrammer.Source;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        byte[] salt = RandomNumberGenerator.GetBytes(16);

        string? key = Environment.GetEnvironmentVariable("Fluxogrammer_Keys", EnvironmentVariableTarget.User);

        if (key == null)
        {
            string saltString = Convert.ToBase64String(salt);
            Console.WriteLine("Não existe");
            Environment.SetEnvironmentVariable("Fluxogrammer_Keys", saltString, EnvironmentVariableTarget.User);
            Console.WriteLine("Criado");
        }

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
        string actualVersion = "v0.2.1";
        string? lastVersion = await VersionChecker.GetLastVersion();
    
        if (lastVersion != actualVersion && lastVersion != null)
        {
            int choose = NotificationWindow.Connect(
                "Atualização disponível",
                $"Uma nova versão está disponível: {lastVersion}\nDeseja baixar agora?",
                0x04 | 0x20
            );

            if (choose == 6)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/Willian-Thdr/Fluxogrammer/releases/latest/download/setup.exe",
                    UseShellExecute = true
                });
            }
        }
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