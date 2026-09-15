namespace Cocus.FileReader.Cli;

internal sealed class FileReaderApp(
    ConsolePrompt prompt,
    FileReaderFactory factory,
    IEncryption[] encryptions,
    IAccessPolicy[] policies)
{
    public void Run()
    {
        prompt.Show("COCUS File Reader");

        try
        {
            do
            {
                ReadFile();
            }
            while (prompt.Confirm("Read another file?"));
        }
        catch (OperationCanceledException)
        {
        }
    }

    private void ReadFile()
    {
        var type = prompt.Choose<FileType>("File type:");
        var encryption = AskEncryption();
        var access = AskAccess();
        var path = prompt.Ask("File path:");

        try
        {
            var reader = factory.Create(type, encryption, access);
            prompt.Show($"{Environment.NewLine}{reader.Read(path)}{Environment.NewLine}");
        }
        catch (Exception exception)
        {
            prompt.Show($"Error: {exception.Message}");
        }
    }

    private IEncryption? AskEncryption() =>
        prompt.Confirm("Is the file encrypted?")
            ? prompt.Choose("Encryption:", encryptions, Describe)
            : null;

    private AccessContext? AskAccess()
    {
        if (!prompt.Confirm("Use role based security?"))
            return null;

        var policy = prompt.Choose("Access policy:", policies, Describe);
        var role = prompt.Ask("Role:");

        return new AccessContext(policy, role);
    }

    private static string Describe(object option) => option.GetType().Name;
}
