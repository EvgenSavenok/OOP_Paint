using System.Windows;
using System.Windows.Media;
using PolygonModule;

namespace StarModule;

[Serializable]
public class FigureStar : FigurePolygon
{
    private List<Point> ListOfPoints { get; }
    public override int NumOfFactory => 5;
    public override string ShapeName { get; set; } = "Звезда";
    public FigureStar(List<Point> listOfPoints, Brush color) 
        : base(listOfPoints, color)
    {
        ListOfPoints = listOfPoints;
        Color = color;
        DrawStrategy = new StarDrawStrategy();
    }
}
