namespace Cocus.FileReader.Cli;

internal sealed class FileReaderFactory
{
    public IFileReader Create(FileType type, IEncryption? encryption, AccessContext? access)
    {
        IFileReader reader = type switch
        {
            FileType.Text when access is not null => throw new NotSupportedException("Role based security is not supported for text files."),
            FileType.Text => new TextFileReader(encryption),
            FileType.Xml when encryption is not null => throw new NotSupportedException("Encrypted XML files are not supported."),
            FileType.Xml => new XmlFileReader(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unsupported file type.")
        };

        return access is null ? reader : new RoleBasedFileReader(reader, access.Policy, access.Role);
    }
}
