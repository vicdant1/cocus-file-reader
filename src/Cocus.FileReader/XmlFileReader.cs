using System.Xml.Linq;

namespace Cocus.FileReader;

public sealed class XmlFileReader(IEncryption? encryption = null) : IFileReader
{
    public string Read(string path)
    {
        var content = File.ReadAllText(path);

        if (encryption is not null)
            content = encryption.Decrypt(content);

        return XDocument.Parse(content).ToString();
    }
}
