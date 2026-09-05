using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Windows;
using Fluxogrammer.Service.CSharpService;

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

        string way = AppContext.BaseDirectory;
        string path = Path.Combine(way, "Service", "JavascriptService", "CheckerVersion.js");
        Console.WriteLine(path);
        
        try
        {
            ProcessStartInfo process = new ProcessStartInfo
            {
                FileName = "node",
                Arguments = "--version",
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
    
            using Process node = Process.Start(process)!;
            string output = node.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            node.WaitForExit();
    
            if (output.Trim().StartsWith("v"))
            {
                ProcessStartInfo start = new ProcessStartInfo
                {
                    FileName = "node",
                    Arguments = $"\"{path}\"",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

              Process.Start(start);
            }
        } catch (System.ComponentModel.Win32Exception)
        {
            NotificationWindow.Connect("ERROR", "Servidor não pode ser iniciado.\n Requisição: Node.js", 0x00 | 0x10);
            Check.Connect();
        }

        OpenConfig.Click += (s, e) =>
        {
            OptionsWindow options = new();
            options.Show();
        };
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