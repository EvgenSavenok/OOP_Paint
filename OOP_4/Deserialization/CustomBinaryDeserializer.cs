using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using BaseShapesClasses;
using Microsoft.Win32;
using OOP_3.Figures;

namespace OOP_3.Deserialization;

public class CustomBinaryDeserializer
{
    private DeserializationDrawer DeserializationDrawer { get; } = new();
    public void BinaryDeserialize(List<AbstractShape> abstractShapes, Dictionary<int, IShapeFactory> comboBoxFactories, Canvas canvas)
    {
        OpenFileDialog openFileDialog = new()
        {
            Filter = "Бинарные файлы (*.dat)|*.dat"
        };
        if (openFileDialog.ShowDialog() == true)
        {
            try
            {
                using FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
#pragma warning disable SYSLIB0011
                BinaryFormatter formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                if ((List<SerializedShape>)formatter.Deserialize(fs) is List<SerializedShape> { Count: not 0 } loadedShapes)
                {
                    abstractShapes.Clear();
                    canvas.Children.Clear();
                    DeserializationDrawer.DrawDeserializedFigures(loadedShapes, comboBoxFactories, abstractShapes, canvas);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка номер 52 при открытии файла. Возможно, " +
                                "Вы загрузили не все модули фигур.");
            }
        }
    }
}
