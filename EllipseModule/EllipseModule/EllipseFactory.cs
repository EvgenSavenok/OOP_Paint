using System.Windows;
using System.Windows.Media;
using BaseShapesClasses;

namespace EllipseModule;

public class EllipseFactory : IShapeFactory
{
    public AbstractShape CreateShape(List<Point> listOfPoints, Brush color)
    {
        return new FigureEllipse(listOfPoints, color);
    }

    public string GetFactoryName()
    {
        return "Эллипс";
    }

    public int GetFactoryNum()
    {
        return 1;
    }
}
