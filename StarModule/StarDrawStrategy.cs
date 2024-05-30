using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using BaseShapesClasses;

namespace StarModule;

[Serializable]
public class StarDrawStrategy : IDrawStrategy
{
    public Shape DrawShape(AbstractShape abstractShape)
    {
        List<Point> listOfPoints = abstractShape.ListOfPoints;
        Point startPoint = listOfPoints[0];
        Point endPoint = listOfPoints[1];
        double lineLength = Math.Sqrt(Math.Pow(endPoint.X - startPoint.X, 2) + Math.Pow(endPoint.Y - startPoint.Y, 2));
        double angle = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
        double radius = lineLength / (2 * Math.Sin(Math.PI / 5));
        Point[] starPoints = new Point[10];
        for (int i = 0; i < 10; i++)
        {
            double currentAngle = angle + i * Math.PI / 5;
            if (i % 2 == 0)
            {
                starPoints[i] = new Point(startPoint.X + radius * Math.Cos(currentAngle),
                    startPoint.Y + radius * Math.Sin(currentAngle));
            }
            else
            {
                starPoints[i] = new Point(startPoint.X + (radius / 2) * Math.Cos(currentAngle),
                    startPoint.Y + (radius / 2) * Math.Sin(currentAngle));
            }
        }
        StreamGeometry starGeometry = new StreamGeometry();
        using (StreamGeometryContext context = starGeometry.Open())
        {
            context.BeginFigure(starPoints[0], true, true);
            for (int i = 1; i < 10; i++)
            {
                context.LineTo(starPoints[i], true, false);
            }
        }
        Path path = new Path
        {
            Stroke = abstractShape.Color,
            StrokeThickness = 5,
            Data = starGeometry,
        };
        return path;
    }
}
