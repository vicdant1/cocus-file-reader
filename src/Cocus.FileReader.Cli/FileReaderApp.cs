namespace Cocus.FileReader.Cli;

internal sealed class FileReaderApp(ConsolePrompt prompt, FileReaderFactory factory)
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
        var path = prompt.Ask("File path:");
        var reader = factory.Create(type);

        try
        {
            prompt.Show($"{Environment.NewLine}{reader.Read(path)}{Environment.NewLine}");
        }
        catch (Exception exception)
        {
            prompt.Show($"Error: {exception.Message}");
        }
    }
}
