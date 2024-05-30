using System.Windows;
using System.Windows.Media;
using BaseShapesClasses;
using StarModule;

namespace CurveModule;

public class CurveFactory : IShapeFactory
{
    public AbstractShape CreateShape(List<Point> listOfPoints, Brush color)
    {
        return new FigureStar(listOfPoints, color);
    }

    public string GetFactoryName()
    {
        return "Звезда";
    }

    public int GetFactoryNum()
    {
        return 5;
    }
}
