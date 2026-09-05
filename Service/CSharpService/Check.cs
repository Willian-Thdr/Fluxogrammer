using System.Diagnostics;

namespace Fluxogrammer.Service.CSharpService;
public class Check
{
    public static async void Connect()
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
}