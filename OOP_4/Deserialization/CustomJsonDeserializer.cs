using System.IO;
using System.Windows;
using BaseShapesClasses;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace OOP_3.Deserialization;

public class CustomJsonDeserializer
{
    public List<AbstractShape> JsonDeserialize(List<AbstractShape> _abstractShapes)
    {
        OpenFileDialog openFileDialog = new()
        {
            Filter = "JSON файлы (*.json)|*.json"
        };
        if (openFileDialog.ShowDialog() == true)
        {
            try
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                };
                return JsonConvert.DeserializeObject<List<AbstractShape>>(json, settings);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка номер 52 при открытии файла. Возможно, " +
                                "Вы загрузили не все модули фигур.");
            }
        }
        return null;
    }
}
