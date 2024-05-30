using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using BaseShapesClasses;

namespace LineModule;

public class LineFactory : IShapeFactory
{
    public AbstractShape CreateShape(List<Point> listOfPoints, Brush color)
    {
        return new FigureLine(listOfPoints, color);
    }

    public string GetFactoryName()
    {
        return "Линия";
    }

    public int GetFactoryNum()
    {
        return 0;
    }
}
