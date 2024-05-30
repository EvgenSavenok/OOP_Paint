using System.Windows;
using System.Windows.Media;
using PolygonModule;

namespace RectangleModule;

[Serializable]
public class FigureRectangle : FigurePolygon
{
    private List<Point> ListOfPoints { get; }
    public override int NumOfFactory => 3;
    public override string ShapeName { get; set; } = "Прямоугольник";
    public FigureRectangle(List<Point> listOfPoints, Brush color) 
        : base(listOfPoints, color)
    {
        ListOfPoints = listOfPoints;
        Color = color;
        DrawStrategy = new RectangleDrawStrategy();
    }
}
