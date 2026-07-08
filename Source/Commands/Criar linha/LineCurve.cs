using System.Windows;
using System.Windows.Media;

public static class LineCurve
{
    public static PathGeometry CriarCurva(Point origem, Point destino)
    {
        double dx = destino.X - origem.X;

        Point Control1 = new Point(origem.X + dx * 0.5, origem.Y);
        Point Control2 = new Point(origem.X + dx * 0.5, destino.Y);

        PathFigure figure = new PathFigure
        {
            StartPoint = origem,
            IsClosed = false
        };

        figure.Segments.Add(new BezierSegment(Control1, Control2, destino, true));

        PathGeometry geometry = new PathGeometry();
        geometry.Figures.Add(figure);

        return geometry;
    }
}