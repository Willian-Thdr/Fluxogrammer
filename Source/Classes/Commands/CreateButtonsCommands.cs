using System.Windows.Controls;
using Fluxogrammer.Source;

public class CreateButtonsCommands
{
    public static bool Connect(Button command, TextBox name, TextBox description)
    {
        bool checker = false;

        command.Click += (s, e) =>
        {
            string txtCamp = name.Text;
            string? details = description.Text;

            if (string.IsNullOrWhiteSpace(txtCamp))
            {
                Console.WriteLine("Por Favor. Preencha todos os campos");
                checker = false;
                return;
            }
            else
            {
                TemplateDataFlux.TemplateArchive(txtCamp, details);
                checker = true;
            }
        };

        return checker;
    }
}