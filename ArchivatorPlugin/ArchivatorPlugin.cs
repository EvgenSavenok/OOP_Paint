using System.IO;
using System.IO.Compression;
using System.Windows;
using System.Windows.Controls;
using BaseShapesClasses;
using Microsoft.Win32;
using OOP_3;
using OOP_3.Deserialization;
using OOP_3.Figures;
using OOP_3.Functionality;
using OOP_3.Serialization;

namespace External_plugins;

public class ArchivatorPlugin : IFunctionality
{
    public string GetName => "Архиватор XML";

    public void SaveToFile(List<AbstractShape> abstractShapes)
    {
        CustomXMLSerializer myXmlSerializer = new();
        string path = myXmlSerializer.XmlSerialize(abstractShapes);
        if (!path.EndsWith(".xml"))
        {
            path += ".xml";
        }
        using (FileStream sourceStream = new FileStream(path, FileMode.Open))
        {
            using FileStream fileArchive = File.Create(path + ".gz");
            using (GZipStream compressionStream = new GZipStream(fileArchive, CompressionLevel.Optimal, true))
            {
                sourceStream.CopyTo(compressionStream);
            }
            MessageBox.Show(
                $"Сжатие прошло успешно.\nИсходный размер: {sourceStream.Length}\nСжатый размер: {fileArchive.Length}");
        }
        File.Delete(path);
    }

    public List<AbstractShape> LoadFile(List<AbstractShape> abstractShapes, Dictionary<int, IShapeFactory> dictionary)
    {
        OpenFileDialog openFileDialog = new()
        {
            Filter = "gz файлы (*.gz)|*.gz"
        };
        if (openFileDialog.ShowDialog() == true)
        {
            using FileStream sourceStream = new FileStream(openFileDialog.FileName, FileMode.OpenOrCreate);
            using GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress);
            using MemoryStream memoryStream = new(); //Для сохранения потока в памяти
            decompressionStream.CopyTo(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            CustomXmlDeserializer myXmlDeserializer = new();
            MessageBox.Show("Список фигур успешно загружен!");
            return myXmlDeserializer.XmlDeserialize(dictionary, memoryStream);
        }
        return null;
    }
}
