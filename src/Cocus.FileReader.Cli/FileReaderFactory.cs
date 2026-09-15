namespace Cocus.FileReader.Cli;

internal sealed class FileReaderFactory
{
    public IFileReader Create(FileType type, IEncryption? encryption) => type switch
    {
        FileType.Text => new TextFileReader(encryption),
        FileType.Xml when encryption is not null => throw new NotSupportedException("Encrypted XML files are not supported."),
        FileType.Xml => new XmlFileReader(),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unsupported file type.")
    };
}
