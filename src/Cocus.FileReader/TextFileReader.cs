namespace Cocus.FileReader;

public sealed class TextFileReader : IFileReader
{
    public string Read(string path) => File.ReadAllText(path);
}
