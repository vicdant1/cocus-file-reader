namespace Cocus.FileReader;

public sealed class TextFileReader(IEncryption? encryption = null) : IFileReader
{
    public string Read(string path)
    {
        var content = File.ReadAllText(path);
        return encryption is null ? content : encryption.Decrypt(content);
    }
}
