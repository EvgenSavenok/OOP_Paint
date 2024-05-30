using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using BaseShapesClasses;
using Microsoft.Win32;
using OOP_3.Figures;

namespace OOP_3.Serialization;

public class CustomXMLSerializer
{
    public string XmlSerialize(List<AbstractShape> _abstractShapes)
    {
        SaveFileDialog saveFileDialog = new()
        {
            Filter = "XML файлы (*.xml)|*.xml|Все файлы (*.*)|*.*"
        };
        if (saveFileDialog.ShowDialog() == true)
        {
            if (!saveFileDialog.FileName.EndsWith(".xml"))
                saveFileDialog.FileName += ".xml";
            try
            {
                using FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate);
                List<SerializedShape> xmlShapes = new();
                foreach (var shape in _abstractShapes)
                {
                    xmlShapes.Add(new()
                    {
                        ListOfPoints = shape.ListOfPoints, Color = shape.Color, 
                        NumOfFactory = shape.NumOfFactory, FactoryName = shape.ShapeName,
                        TagShape = shape.NumOfFactory
                    });
                }
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<SerializedShape>));
                xmlSerializer.Serialize(fs, xmlShapes);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка номер 52 при сохранении файла.");
            }
        }
        return saveFileDialog.FileName;
    }
}
