namespace Cocus.FileReader.Cli;

internal sealed class FileReaderFactory
{
    public IFileReader Create(FileType type, IEncryption? encryption, AccessContext? access)
    {
        IFileReader reader = type switch
        {
            FileType.Text => new TextFileReader(encryption),
            FileType.Xml => new XmlFileReader(encryption),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unsupported file type.")
        };

        return access is null ? reader : new RoleBasedFileReader(reader, access.Policy, access.Role);
    }
}
