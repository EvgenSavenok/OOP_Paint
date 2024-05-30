using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using BaseShapesClasses;

namespace CurveModule;

[Serializable]
public class CurveDrawStrategy : IDrawStrategy
{
    public Shape DrawShape(AbstractShape abstractShape)
    {
        List<Point> listOfPoints = abstractShape.ListOfPoints;
        Point startPoint = listOfPoints[0];
        Point endPoint = listOfPoints[1];
        Point controlPoint = new Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2 - 100);
        PathGeometry pathGeometry = new PathGeometry();
        PathFigure pathFigure = new PathFigure();
        pathFigure.StartPoint = startPoint;
        BezierSegment bezierSegment = new BezierSegment(controlPoint, controlPoint, endPoint, true);
        pathFigure.Segments.Add(bezierSegment);
        pathGeometry.Figures.Add(pathFigure);
        Path path = new Path
        {
            Stroke = abstractShape.Color,
            StrokeThickness = 5,
            Data = pathGeometry,
        };
        return path;
    }
}
