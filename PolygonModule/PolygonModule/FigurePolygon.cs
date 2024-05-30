using System.Windows;
using System.Windows.Media;
using BaseShapesClasses;

namespace PolygonModule;

[Serializable]
public class FigurePolygon : AbstractShape
{
    private List<Point> ListOfPoints { get; }
    public override int NumOfFactory => 2;
    public override string ShapeName { get; set; } = "Многоугольник";
    public FigurePolygon(List<Point> listOfPoints, Brush color)
        : base(listOfPoints, color)
    {
        ListOfPoints = listOfPoints;
        Color = color;
        DrawStrategy = new PolygonDrawStrategy();
    }
}
