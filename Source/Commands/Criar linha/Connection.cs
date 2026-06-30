using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using static CreateObject;

public class Connection
{
    public BlocoVisual Origem { get; }
    public BlocoVisual Destino { get; }

    public Line Linha { get; }

    public Connection(BlocoVisual origem, BlocoVisual destino)
    {
        Origem = origem;
        Destino = destino;

        Linha = new Line
        {
            Stroke = Brushes.Black,
            StrokeThickness = 2
        };

        Atualizar();
    }

    public void Atualizar()
    {
        Point inicio = GetPointObject.Calcular(Origem.Dados, Destino.Dados);
        Point destino = GetPointObject.Calcular(Destino.Dados, Origem.Dados);

        Linha.X1 = inicio.X;
        Linha.Y1 = inicio.Y;
        Linha.X2 = destino.X;
        Linha.Y2 = destino.Y;
    }
}