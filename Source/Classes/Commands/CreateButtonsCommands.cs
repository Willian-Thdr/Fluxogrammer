using System.Windows.Controls;
using Fluxogrammer.Source;

public class CreateButtonsCommands
{
    public static void Connect(Button command, TextBox name, TextBox description, Action close)
    {
        command.Click += (s, e) =>
        {
            string txtCamp = name.Text;
            string? details = description.Text;

            if (string.IsNullOrWhiteSpace(txtCamp))
            {
                Console.WriteLine("Por Favor. Preencha todos os campos");
                return;
            }
            else
            {
                TemplateDataFlux.TemplateArchive(txtCamp, details, close);
            }
        };
    }
}