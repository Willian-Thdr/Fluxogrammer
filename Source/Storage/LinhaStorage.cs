using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using static CreateObject;

public class LinhaStorage
{
    public BlocoVisual Origem { get; set; }
    public BlocoVisual Destino { get; set; }

    public Path Path { get; }

    public LinhaStorage(BlocoVisual origem, BlocoVisual destino)
    {
        this.Origem = origem;
        this.Destino = destino;

        Path = new Path()
        {
            Stroke = Brushes.Black,
            StrokeThickness = 2
        };

        Update();
    }

    public void Update()
    {
        double x1 = Origem.Dados.X + Origem.Dados.Wdt; 
        double y1 = Origem.Dados.Y + Origem.Dados.Hegt / 2; 

        double x2 = Destino.Dados.X + Destino.Dados.Wdt; 
        double y2 = Destino.Dados.Y + Destino.Dados.Hegt / 2; 

        PathFigure figure = new();
        figure.StartPoint = new System.Windows.Point(x1, y1);

        BezierSegment curva = new BezierSegment()
        {
            Point1 = new Point(x1 + 80, y1),  
            Point2 = new Point(x2 - 80, y2),
            Point3 = new Point(x2, y2)
        };

        figure.Segments.Add(curva);

        PathGeometry geometry = new PathGeometry();
        geometry.Figures.Add(figure);

        Path.Data = geometry;
    }
}