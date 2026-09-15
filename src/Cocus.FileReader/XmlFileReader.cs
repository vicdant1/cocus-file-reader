using System.Xml.Linq;

namespace Cocus.FileReader;

public sealed class XmlFileReader : IFileReader
{
    public string Read(string path) => XDocument.Load(path).ToString();
}
