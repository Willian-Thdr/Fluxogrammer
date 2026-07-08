using System.Windows;
using System.Windows.Controls;
using static CreateObject;

public class GetPointObject
{
    public static BlocoVisual blocoOrigem;
    public static BlocoVisual blocoDestino2;
    public static Connection connection;
    public static List<Connection> connections = new List<Connection>();
    
    public static void GetPointOrigem(BlocoVisual bloco)
    {
        blocoOrigem = bloco;
    }

    public static void GetPointDestino(BlocoVisual blocoDestino, Canvas canva, ProjetoInfo projetoInfo)
    {
        if (blocoOrigem == null)
            return;

        blocoDestino2 = blocoDestino;

        connection = new Connection(blocoOrigem, blocoDestino2);

        blocoOrigem.Connections.Add(connection);
        blocoDestino2.Connections.Add(connection);

        connections.Add(connection);

        projetoInfo.linhas.Add(new Linhas()
        {
            OrigemId = blocoOrigem.Dados.Id,
            DestinoId = blocoDestino2.Dados.Id
        });

        canva.Children.Add(connection.Linha);

        blocoOrigem = null;
    }

    public static Point Calcular(Objeto origem, Objeto destino)
    {
        Point centroOrigem = new Point(origem.X + origem.Wdt / 2, origem.Y + origem.Hegt /2);
        Point centroDestino = new Point(destino.X + destino.Wdt / 2, destino.Y + destino.Hegt /2);

        double dx = centroDestino.X - centroOrigem.X;

        double halfW = origem.Wdt / 2;

        double pointX = dx >= 0
        ? centroOrigem.X + halfW
        : centroOrigem.X - halfW;

        double pointY = centroOrigem.Y;

        return new Point(pointX, pointY);
    }
}