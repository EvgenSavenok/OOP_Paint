using System.Windows;
using System.Windows.Media;
using BaseShapesClasses;

namespace LineModule;

[Serializable]
public class FigureLine : AbstractShape
{
    private List<Point> ListOfPoints { get; }
    public override int NumOfFactory => 0;
    public override string ShapeName { get; set; } = "Линия";

    public FigureLine(List<Point> listOfPoints, Brush color) 
        : base(listOfPoints, color)
    {
        ListOfPoints = listOfPoints;
        Color = color;
        DrawStrategy = new LineDrawStrategy();
    }
}
