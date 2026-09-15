namespace Cocus.FileReader.Cli;

internal sealed class FileReaderFactory
{
    public IFileReader Create(FileType type) => type switch
    {
        FileType.Text => new TextFileReader(),
        FileType.Xml => new XmlFileReader(),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unsupported file type.")
    };
}
