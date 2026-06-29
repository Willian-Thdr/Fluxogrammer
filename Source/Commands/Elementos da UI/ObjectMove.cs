using System.Windows.Controls;
using System.Windows;

public class ObjectMove
{
    public static void Connect(Canvas canva, CreateObject.BlocoVisual bloco)
    {
        bool press = false;

        Point offset = new();

        bloco.Grid.PreviewMouseLeftButtonDown += (s, e) =>
        {
            FluxConnectionManager.EndConnect(canva, bloco);
            press = true;

            Point mouse = e.GetPosition(canva);

            offset.X = mouse.X - Canvas.GetLeft(bloco.Grid);
            offset.Y = mouse.Y - Canvas.GetTop(bloco.Grid);

            bloco.Grid.CaptureMouse();
        };

        bloco.Grid.MouseMove += (s, e) =>
        {
            if (press)
            {
                Point mouse = e.GetPosition(canva);
        
                Canvas.SetTop(bloco.Grid, mouse.Y - offset.Y);
                Canvas.SetLeft(bloco.Grid, mouse.X - offset.X);
            }            
        };  

        bloco.Grid.MouseLeftButtonUp += (s, e) => 
        {
            press = false;

            bloco.Grid.ReleaseMouseCapture();
        };     
    }
}