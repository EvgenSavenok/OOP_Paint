using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using BaseShapesClasses;
using Microsoft.Win32;
using OOP_3.Figures;

namespace OOP_3.Deserialization;

public class CustomXmlDeserializer
{
    public List<AbstractShape> XmlDeserialize(Dictionary<int, IShapeFactory> comboBoxFactories, Stream stream)
    {
        List<AbstractShape> abstractShapes = new();
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SerializedShape>));
            if (serializer.Deserialize(stream) is List<SerializedShape> { Count: not 0 } loadedShapes)
            {
                for (int i = loadedShapes.Count - 1; i >= 0; i--)
                {
                    var item = loadedShapes[i];
                    for (int j = 0; j < comboBoxFactories.Count; j++)
                    {
                        if (comboBoxFactories[j].GetFactoryNum() == item.TagShape)
                        {
                            comboBoxFactories.TryGetValue(j, out var factory);
                            var shape = factory.CreateShape(item.ListOfPoints, loadedShapes[i].Color);
                            abstractShapes.Add(shape);
                            loadedShapes.RemoveAt(i);
                        }
                    }
                }
                return abstractShapes;
            }
        }
        catch (Exception)
        {
            MessageBox.Show("Ошибка номер 52 при открытии файла. Возможно, " +
                            "Вы загрузили не все модули фигур.");
        }
        return null;
    }
}
