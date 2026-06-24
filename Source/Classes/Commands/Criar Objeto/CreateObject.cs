using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Fluxogrammer.Fluxogramas;

public class CreateObject
{
    public static void Connect(Canvas canva)
    {       
        Grid bloco = new Grid()
        {
            Name = "Objects",
            Width = 100,
            Height = 25,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center
        };
        NameScope.SetNameScope(canva, new NameScope());
        canva.RegisterName(bloco.Name, bloco);

        Border borda = new Border()
        {
            BorderBrush = Brushes.Black,
            BorderThickness = new Thickness(2),
            Background = Brushes.Transparent,
            CornerRadius = new CornerRadius(18)
        };

        bloco.Children.Add(borda);

        Point mouse = Mouse.GetPosition(canva);

        Canvas.SetTop(bloco, mouse.Y - 12.5);
        Canvas.SetLeft(bloco, mouse.X - 50);

        canva.Children.Add(bloco);
        ObjectMove.Connect(bloco, canva);
    }
}