using System.Windows;
using System.Windows.Media;
using BaseShapesClasses;

namespace CurveModule;

public class CurveFactory : IShapeFactory
{
    public AbstractShape CreateShape(List<Point> listOfPoints, Brush color)
    {
        return new FigureCurve(listOfPoints, color);
    }

    public string GetFactoryName()
    {
        return "Кривая";
    }

    public int GetFactoryNum()
    {
        return 4;
    }
}
