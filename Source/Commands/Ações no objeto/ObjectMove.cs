using System.Windows.Controls;
using System.Windows;
using static CreateObject;

public class ObjectMove
{
    public static void Connect(Canvas canva, BlocoVisual bloco, ProjetoInfo projetoInfo)
    {
        bool press = false;
        bool hold = false;

        Point offset = new();

        bloco.Grid.PreviewMouseLeftButtonDown += (s, e) =>
        {
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

                double newX = mouse.X - offset.X;
                double newY = mouse.Y - offset.Y;
        
                Canvas.SetTop(bloco.Grid, mouse.Y - offset.Y);
                Canvas.SetLeft(bloco.Grid, mouse.X - offset.X);

                bloco.Dados.X = newX;
                bloco.Dados.Y = newY;

                foreach(Connection connection in bloco.Connections)
                {
                    connection.Atualizar();
                }
            }            
        };  

        bloco.Grid.MouseLeftButtonUp += (s, e) => 
        {
            press = false;

            bloco.Grid.ReleaseMouseCapture();
        };

        bloco.Grid.MouseLeftButtonDown += (s, e) =>
        {
            GetPointObject.GetPointDestino(bloco, canva, projetoInfo);
        };  
    }
}