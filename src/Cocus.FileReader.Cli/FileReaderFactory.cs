namespace Cocus.FileReader.Cli;

internal sealed class FileReaderFactory
{
    public IFileReader Create(FileType type) => type switch
    {
        FileType.Text => new TextFileReader(),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unsupported file type.")
    };
}
