using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using static CreateObject;

public class GetPointObject
{
    public static BlocoVisual blocoOrigem;

    public static void GetPointOrigem(BlocoVisual bloco)
    {
        blocoOrigem = bloco;
    }

    public static void GetPointDestino(BlocoVisual blocoDestino, Canvas canva)
    {
        if (blocoOrigem == null)
            return;

        Connection connection = new Connection(blocoOrigem, blocoDestino);

        blocoOrigem.Connections.Add(connection);
        blocoDestino.Connections.Add(connection);

        canva.Children.Add(connection.Linha);

        blocoOrigem = null;
    }

    public static Point Calcular(Objeto origem, Objeto destino)
    {
        Point centroOrigem = new Point(origem.X + origem.Wdt / 2, origem.Y + origem.Hegt /2);
        Point centroDestino = new Point(destino.X + destino.Wdt / 2, destino.Y + destino.Hegt /2);

        double dx = centroDestino.X - centroOrigem.X;
        double dy = centroDestino.Y - centroOrigem.Y;

        if (dx == 0 && dy == 0) return centroOrigem;

        double halfW = origem.Wdt / 2;
        double halfH = origem.Hegt / 2;

        double tX = halfW / Math.Abs(dx == 0 ? double.Epsilon : dx);
        double tY = halfH / Math.Abs(dy == 0 ? double.Epsilon : dy);

        double t = Math.Min(tX, tY);

        var line = new Point(centroOrigem.X + dx * t, centroOrigem.Y + dy * t);
        
        return line;
    }
}