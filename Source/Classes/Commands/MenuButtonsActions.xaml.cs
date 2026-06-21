using System.Diagnostics;
using System.Windows.Controls;

public class MenuButtonsActions
{
    public static void GetButtonNew(Button component)
    {
        component.Click += (s, e) =>
        {
            Console.WriteLine("Criar");
            CallNFO.Connect();
        };
    }

    public static void GetButtonLoad(Button component)
    {
        component.Click += (s2, e2) =>
        {
            Console.WriteLine("Carregar");
        };
    }
}