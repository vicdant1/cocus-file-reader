namespace Cocus.FileReader.Cli;

internal sealed class FileReaderApp(ConsolePrompt prompt, FileReaderFactory factory, IEncryption[] encryptions)
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
        var encryption = prompt.Confirm("Is the file encrypted?")
            ? prompt.Choose("Encryption:", encryptions, option => option.GetType().Name)
            : null;
        var path = prompt.Ask("File path:");

        try
        {
            var reader = factory.Create(type, encryption);
            prompt.Show($"{Environment.NewLine}{reader.Read(path)}{Environment.NewLine}");
        }
        catch (Exception exception)
        {
            prompt.Show($"Error: {exception.Message}");
        }
    }
}
