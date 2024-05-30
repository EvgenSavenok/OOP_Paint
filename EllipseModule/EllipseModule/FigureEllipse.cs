using System.Windows;
using System.Windows.Media;
using BaseShapesClasses;

namespace EllipseModule;

[Serializable]
public class FigureEllipse : AbstractShape
{
    private List<Point> ListOfPoints { get; }
    public override int NumOfFactory => 1;
    public override string ShapeName { get; set; } = "Эллипс";

    public FigureEllipse(List<Point> listOfPoints, Brush color)
    : base(listOfPoints, color)
    {
        ListOfPoints = listOfPoints;
        Color = color;
        DrawStrategy = new EllipseDrawStrategy();
    }
}
