using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Media;
using BaseShapesClasses;
using Microsoft.Win32;
using OOP_3.Figures;

namespace OOP_3.Serialization;

public class CustomBinarySerializer
{
    public void BinarySerialize(List<AbstractShape> _abstractShapes)
    {
        SaveFileDialog saveFileDialog = new()
        {
            Filter = "Бинарные файлы (*.dat)|*.dat|Все файлы (*.*)|*.*"
        };
        if (saveFileDialog.ShowDialog() == true)
        {
            List<SerializedShape> xmlShapes = new();
            foreach (var shape in _abstractShapes)
            {
                xmlShapes.Add(new()
                {
                    ListOfPoints = shape.ListOfPoints, Color = Brushes.Black, NumOfFactory = shape.NumOfFactory, 
                    FactoryName = shape.ShapeName, TagShape = shape.NumOfFactory
                });
            }
            if (!saveFileDialog.FileName.EndsWith(".dat"))
                saveFileDialog.FileName += ".dat";
            using FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate);
#pragma warning disable SYSLIB0011
            BinaryFormatter formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011
            formatter.Serialize(fs, xmlShapes);
        }
    }
}
