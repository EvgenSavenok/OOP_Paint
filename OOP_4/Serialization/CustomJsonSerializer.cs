using System.IO;
using System.Text;
using System.Windows;
using BaseShapesClasses;
using Microsoft.Win32;
using Newtonsoft.Json;
using OOP_3.Figures;

namespace OOP_3.Serialization;

public class CustomJsonSerializer
{
    public string JsonSerialize(List<AbstractShape> _abstractShapes)
    {
        SaveFileDialog saveFileDialog = new()
        {
            Filter = "JSON файлы (*.json)|*.json|Все файлы (*.*)|*.*"
        };
        if (saveFileDialog.ShowDialog() == true)
        {
            if (!saveFileDialog.FileName.EndsWith(".json"))
                saveFileDialog.FileName += ".json";
            using FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Objects
            };
            try
            {
                string json = JsonConvert.SerializeObject(_abstractShapes, settings);
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                fs.Write(bytes, 0, bytes.Length);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка номер 52 при сохранении файла.");
            }
        }
        return saveFileDialog.FileName;
    }
}
