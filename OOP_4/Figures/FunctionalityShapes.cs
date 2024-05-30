using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;
using BaseShapesClasses;

namespace OOP_3.Figures;

public class FunctionalityShapes
{
    public List<Point> ListOfPoints { get; set; }
    public Brush Color;
    public int NumOfFactory { get; set; }
    public string ShapeName { get; set; }
}
