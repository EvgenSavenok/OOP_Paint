using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Serialization;
using BaseShapesClasses;
using Microsoft.Win32;
using Newtonsoft.Json;
using OOP_3.Figures;
using OOP_3.Functionality;
using OOP_3.Serialization;
using Formatting = Newtonsoft.Json.Formatting;

namespace FormatConvertingModule;

public class Convertor : IFunctionality
{
    public string GetName => "Конвертор JSON в XML";

    public void SaveToFile(List<AbstractShape> abstractShapes)
    {
        CustomJsonSerializer jsonSerializer = new CustomJsonSerializer();
        var jsonFilePath = jsonSerializer.JsonSerialize(abstractShapes);
        if (jsonFilePath != "")
        {
            string json = File.ReadAllText(jsonFilePath);
            if (jsonFilePath.EndsWith(".json"))
                jsonFilePath = jsonFilePath.Remove(jsonFilePath.Length - 5, 5);
            string xmlFilePath = jsonFilePath + ".xml";
            json = "{\n   \"shapes\": [" + json + "   \n]\n}";
            XmlDocument doc = JsonConvert.DeserializeXmlNode(json);
            doc.Save(xmlFilePath);
            File.Delete(jsonFilePath + ".json");
        }
    }

    public List<AbstractShape> LoadFile(List<AbstractShape> abstractShapes, Dictionary<int, IShapeFactory> _comboBoxFactories)
    {
        var settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Objects
        };
        OpenFileDialog openFileDialog = new()
        {
            Filter = "XML файлы (*.xml)|*.xml"
        };
        if (openFileDialog.ShowDialog() == true)
        {
            string xml = File.ReadAllText(openFileDialog.FileName);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string jsonText = JsonConvert.SerializeXmlNode(doc);
            string jsonStartFormatStr = "\"shapes\":{\"shapes\":[";
            string jsonEndingFormatStr = "]}";
            int index = jsonText.IndexOf(jsonStartFormatStr);
            jsonText = jsonText.Remove(index, jsonStartFormatStr.Length);
            index = jsonText.IndexOf(jsonEndingFormatStr);
            jsonText = jsonText.Remove(index, jsonEndingFormatStr.Length);
            jsonText = "[\n " + jsonText + "\n]";
            return JsonConvert.DeserializeObject<List<AbstractShape>>(jsonText, settings);
        }
        return null;
    }
}
