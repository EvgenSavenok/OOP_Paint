using System.Windows.Controls;
using System.Windows.Media;
using OOP_3.Figures;
using BaseShapesClasses;

namespace OOP_3.Deserialization;

public class DeserializationDrawer
{
    public void DrawDeserializedFigures(List<SerializedShape> loadedShapes, Dictionary<int, IShapeFactory> comboBoxFactories, List<AbstractShape> abstractShapes,
                                        Canvas canvas)
    {
        foreach (var item in loadedShapes)
        {
            string itemName = item.FactoryName;
            int index = -1;
            for (int i = 0; i < comboBoxFactories.Count; i++)
            {
                if (comboBoxFactories[i].GetFactoryName() == itemName)
                {
                    index = i;
                    break;
                }
            }
            var factory = comboBoxFactories[index];
            var shape = factory.CreateShape(item.ListOfPoints, item.Color);
            if (shape.Color == null)
                shape.Color = Brushes.Black;
            abstractShapes.Add(shape);
            shape.CanvasIndex = -1;
            shape.Draw(canvas);
        }
    }
}
