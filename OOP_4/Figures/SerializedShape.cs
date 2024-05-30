using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace OOP_3.Figures;

[Serializable]
[XmlInclude(typeof(SolidColorBrush))] //For XML, because exception occurred without this 
[XmlInclude(typeof(MatrixTransform))]
public class SerializedShape
{
    public List<Point> ListOfPoints { get; set; }
    [NonSerialized]
    public Brush Color;
    public int NumOfFactory { get; set; }
    public string FactoryName { get; set; }
    public int TagShape { get; set; }
}
