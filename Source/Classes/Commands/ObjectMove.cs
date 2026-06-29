using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;

public class ObjectMove
{
    public static void Connect(Canvas canva, Grid bloco, TextBox txt)
    {
        bool press = false;
        Point offset = new();

            bloco.PreviewMouseLeftButtonDown += (s, e) =>
            {
                press = true;
    
                Point mouse = e.GetPosition(canva);
    
                offset.X = mouse.X - Canvas.GetLeft(bloco);
                offset.Y = mouse.Y - Canvas.GetTop(bloco);
    
                bloco.CaptureMouse();
            };
    
            bloco.MouseMove += (s, e) =>
            {
                if (press)
                {
                    Point mouse = e.GetPosition(canva);
            
                    Canvas.SetTop(bloco, mouse.Y - offset.Y);
                    Canvas.SetLeft(bloco, mouse.X - offset.X);
                }            
            };  
    
            bloco.MouseLeftButtonUp += (s, e) => 
            {
                press = false;
    
                bloco.ReleaseMouseCapture();
            };     

            bloco.PreviewMouseRightButtonDown += (s, e) =>
            {
                ContextMenu menu = new();

                MenuItem rename = new MenuItem();
                rename.Header = "Renomear";

                MenuItem expandir = new MenuItem();
                expandir.Header = "Expandir";

                MenuItem recolher = new MenuItem();
                recolher.Header = "Recolher";

                MenuItem del = new MenuItem();
                del.Header = "Deletar";

                rename.Click += (s2, e2) =>
                {
                    txt.IsReadOnly = false;
                    txt.Focus();                   
                };

                expandir.Click += (s2, e2) =>
                {
                    bloco.Height = double.NaN;
                };

                recolher.Click += (s2, e2) =>
                {
                    bloco.Height = 25;
                };

                del.Click += (s2, e2) =>
                {
                    canva.Children.Remove(bloco);
                };

                menu.Placement = PlacementMode.MousePoint;

                menu.Items.Add(rename);

                if (bloco.Height <= 25)
                {
                    menu.Items.Add(expandir);
                    menu.Items.Remove(recolher);
                }
                else
                {
                    menu.Items.Add(recolher);
                    menu.Items.Remove(expandir);
                }

                menu.Items.Add(del);

                menu.IsOpen = true;
            };
    }
}