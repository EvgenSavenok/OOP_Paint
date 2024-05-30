using System.Windows;
using System.Windows.Media;
using LineModule;

namespace CurveModule;

[Serializable]
public class FigureCurve : FigureLine
{
    private List<Point> ListOfPoints { get; }
    public override int NumOfFactory => 4;
    public override string ShapeName { get; set; } = "Кривая";
    public FigureCurve(List<Point> listOfPoints, Brush color) 
        : base(listOfPoints, color)
    {
        ListOfPoints = listOfPoints;
        Color = color;
        DrawStrategy = new CurveDrawStrategy();
    }
}
