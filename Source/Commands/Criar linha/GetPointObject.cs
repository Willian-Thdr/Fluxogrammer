using System.Windows;
using System.Windows.Controls;
using static CreateObject;

public class GetPointObject
{
    public static BlocoVisual blocoOrigem;
    public static Connection connection;
    public static void GetPointOrigem(BlocoVisual bloco)
    {
        blocoOrigem = bloco;
    }

    public static void GetPointDestino(BlocoVisual blocoDestino, Canvas canva, ProjetoInfo projetoInfo)
    {
        if (blocoOrigem == null)
            return;

        connection = new Connection(blocoOrigem, blocoDestino);

        blocoOrigem.Connections.Add(connection);
        blocoDestino.Connections.Add(connection);

        projetoInfo.linhas.Add(new Linhas()
        {
            OrigemId = blocoOrigem.Dados.Id,
            DestinoId = blocoDestino.Dados.Id
        });

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

        double point1 = centroOrigem.X + dx *t;
        double point2 = centroOrigem.Y + dy *t;

        var line = new Point(point1, point2);

        return line;
    }
}