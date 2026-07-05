using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

public class CreateObject
{
    public static void Connect(Canvas canva, int x, ProjetoInfo projetoInfo)
    {
        Point mouse = Mouse.GetPosition(canva);

        Objeto objeto = new Objeto()
        {
            Id = $"Object_{x}",
            content = $"Novo objeto {x}",
            X = mouse.X - 50,
            Y = mouse.Y - 12.5,
            Wdt = 125,
            Hegt = 27
        };

        CriarBloco(canva, objeto, projetoInfo);
    }
    
    public static BlocoVisual CreateFromFile(Canvas canva, Objeto obj, ProjetoInfo projetoInfo)
    {
        return CriarBloco(canva, obj, projetoInfo);
    }

    private static BlocoVisual CriarBloco(Canvas canva, Objeto obj, ProjetoInfo projetoInfo)
    {
        BlocoVisual bloco = new(obj);

        NameScope.SetNameScope(canva, new NameScope());
        canva.RegisterName(bloco.Grid.Name, bloco.Grid);

        Canvas.SetLeft(bloco.Grid, obj.X);
        Canvas.SetTop(bloco.Grid, obj.Y);

        ObjectMove.Connect(canva, bloco, projetoInfo);
        ObjectInteract.Connect(canva, bloco, obj);

        canva.Children.Add(bloco.Grid);

        bloco.TextBox.KeyDown += (s, e) =>
        {
            if (e.Key == Key.Enter)
            {
                bloco.TextBox.IsReadOnly = true;
                Keyboard.ClearFocus();
                e.Handled = true;
            }
        };

        return bloco;
    }

    public class BlocoVisual
    {
        public Objeto Dados { get; }
        public Grid Grid { get; }
        public TextBox TextBox { get; }
        public Border Border { get; }
        public List<Connection> Connections { get; set; } = new();

        public BlocoVisual(Objeto obj)
        {
            Dados = obj;

            Grid = new Grid()
            {
                Name = obj.Id,
                Width = obj.Wdt,
                Height = obj.Hegt
            };
    
            Border = new Border()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                Background = Brushes.Transparent,
                CornerRadius = new CornerRadius(18)
            };
    
            TextBox = new TextBox()
            {
                Text = obj.content,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                IsReadOnly = true,
                TextWrapping = TextWrapping.Wrap,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Margin = new Thickness(5)
            };

            Grid.Children.Add(Border);
            Grid.Children.Add(TextBox);
        }
    }
}