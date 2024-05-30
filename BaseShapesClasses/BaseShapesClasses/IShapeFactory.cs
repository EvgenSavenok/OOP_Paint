using System.Windows;
using System.Windows.Media;

namespace BaseShapesClasses;

public interface IShapeFactory
{
    public AbstractShape CreateShape(List<Point> listOfPoints, Brush color);
    public string GetFactoryName();
    public int GetFactoryNum();
}
