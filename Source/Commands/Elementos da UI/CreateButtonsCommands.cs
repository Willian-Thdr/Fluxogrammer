using System.Windows.Controls;

public class CreateButtonsCommands
{
    public static void Connect(Button command, TextBox name, TextBox description, Action close)
    {
        command.Click += (s, e) =>
        {
            string txtCamp = name.Text;
            string? details = description.Text;

            TemplateDataFlux.TemplateArchive(txtCamp, details, close);
        };
    }
}