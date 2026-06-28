using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

public class CreateObject
{
    public static void Connect(Canvas canva, int x)
    {       
        Grid bloco = new Grid()
        {
            Name = "Object_" + x,
            Width = 125,
            Height = 25
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

        TextBox txt = new TextBox()
        {
            HorizontalContentAlignment = HorizontalAlignment.Center,
            VerticalContentAlignment = VerticalAlignment.Center,
            Background = Brushes.Transparent,
            BorderThickness = new Thickness(0),
            IsReadOnly = true,
            TextWrapping = TextWrapping.Wrap,
            VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
            Margin = new Thickness(5)
        };

        bloco.Children.Add(borda);
        bloco.Children.Add(txt);

        Point mouse = Mouse.GetPosition(canva);

        Canvas.SetTop(bloco, mouse.Y - 12.5);
        Canvas.SetLeft(bloco, mouse.X - 50);

        ObjectMove.Connect(canva, bloco, txt);

        canva.Children.Add(bloco);

        txt.KeyDown += (s, e) =>
        {
            if (e.Key == Key.Enter)
            {
                txt.IsReadOnly = true;
                Keyboard.ClearFocus();
                e.Handled = true;
            }
        };
    }
}