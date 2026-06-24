using System.Windows;

namespace Fluxogrammer.Source;
public partial class NewFileOptions : Window
{
    public NewFileOptions()
    {
        InitializeComponent();
        CreateButtonsCommands.Connect(CreateNew, PutName, Description, Close);
    }
}