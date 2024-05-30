using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using BaseShapesClasses;

namespace EllipseModule;
[Serializable]
public class EllipseDrawStrategy : IDrawStrategy
{
    public Shape DrawShape(AbstractShape abstractShape)
    {
        var ellipse = abstractShape as FigureEllipse;
        List<Point> listOfPoints = ellipse.ListOfPoints;
        Point startPoint = listOfPoints[0];
        Point endPont = listOfPoints[1];
        Rect rect = new Rect(startPoint, endPont);
        EllipseGeometry ellipseGeometry = new EllipseGeometry(rect);
        Path path = new Path
        {
            Stroke = abstractShape.Color,
            StrokeThickness = 5,
            Data = ellipseGeometry,
        };
        return path;
    }
}
