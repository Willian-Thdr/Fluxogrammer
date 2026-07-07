using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using static CreateObject;

public class Connection
{
    public  BlocoVisual Origem { get; set; }
    public BlocoVisual Destino { get; set; }
    public static Point inicioPoint { get; set; }
    public static Point destinoPoint { get; set; }

    public Line Linha { get; set; }

    public Connection(BlocoVisual origem, BlocoVisual destino)
    {
        Origem = origem;
        Destino = destino;

        Linha = new Line
        {
            Style = (Style)Application.Current.FindResource("LineStyle"),
            StrokeThickness = 2
        };

        Atualizar();
    }

    public void Atualizar()
    {
        inicioPoint = GetPointObject.Calcular(Origem.Dados, Destino.Dados);
        destinoPoint = GetPointObject.Calcular(Destino.Dados, Origem.Dados);

        Linha.X1 = inicioPoint.X;
        Linha.Y1 = inicioPoint.Y;
        Linha.X2 = destinoPoint.X;
        Linha.Y2 = destinoPoint.Y;
    }
}