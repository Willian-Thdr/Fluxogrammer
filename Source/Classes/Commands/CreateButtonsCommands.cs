using System.Windows.Controls;

public class CreateButtonsCommands
{
    public static void Connect(Button command, TextBox name)
    {
        command.Click += (s, e) =>
        {
            string txtCamp = name.Text;

            if (string.IsNullOrWhiteSpace(txtCamp))
            {
                Console.WriteLine("Por Favor. Preencha todos os campos");
                return;    
            }
            else
            {
                Console.WriteLine(txtCamp);                
            }
        };
    }
}