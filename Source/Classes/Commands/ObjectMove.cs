using System.Windows.Controls;
using System.Windows;

public class ObjectMove
{
    public static void Connect(Grid bloco, Canvas canva)
    {
        bool press = false;
        Point offset = new();

        bloco.MouseLeftButtonDown += (s, e) =>
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

            bloco.CaptureMouse();
        };  
    }
}