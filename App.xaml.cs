using System.Runtime.InteropServices;
using System.Windows;

namespace Fluxogrammer;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    [DllImport("kernel32.dll")]
    private static extern bool AllocConsole();

    protected override void OnStartup(StartupEventArgs e)
    {
        AllocConsole();
        base.OnStartup(e);
    }

    // protected override void OnExit(ExitEventArgs e)
    // {
        // AllocConsole();
        // base.OnExit(e);
    // }
}

