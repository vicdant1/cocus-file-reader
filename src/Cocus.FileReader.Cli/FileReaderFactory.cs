namespace Cocus.FileReader.Cli;

internal sealed class FileReaderFactory
{
    public IFileReader Create(FileType type, IEncryption? encryption, AccessContext? access)
    {
        IFileReader reader = type switch
        {
            FileType.Text => new TextFileReader(encryption),
            FileType.Xml => new XmlFileReader(encryption),
            FileType.Json when encryption is not null => throw new NotSupportedException("Encrypted JSON files are not supported."),
            FileType.Json when access is not null => throw new NotSupportedException("Role based security is not supported for JSON files."),
            FileType.Json => new JsonFileReader(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unsupported file type.")
        };

        return access is null ? reader : new RoleBasedFileReader(reader, access.Policy, access.Role);
    }
}
