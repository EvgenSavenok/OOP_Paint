using System.Windows;
using System.Windows.Media;
using BaseShapesClasses;

namespace PolygonModule;

public class PolygonFactory : IShapeFactory
{
    public AbstractShape CreateShape(List<Point> listOfPoints, Brush color)
    {
        return new FigurePolygon(listOfPoints, color);
    }

    public string GetFactoryName()
    {
        return "Многоугольник";
    }

    public int GetFactoryNum()
    {
        return 2;
    }
}
