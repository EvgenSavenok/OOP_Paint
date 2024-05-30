using System.Windows;
using System.Windows.Media;
using BaseShapesClasses;

namespace RectangleModule;

public class RectangleFactory : IShapeFactory
{
    public AbstractShape CreateShape(List<Point> listOfPoints, Brush color)
    {
        return new FigureRectangle(listOfPoints, color);
    }
    
    public string GetFactoryName()
    {
        return "Прямоугольник";
    }

    public int GetFactoryNum()
    {
        return 3;
    }
}
