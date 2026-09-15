namespace Cocus.FileReader.Tests;

public sealed class TempFile : IDisposable
{
    public TempFile(string content)
    {
        Path = System.IO.Path.GetTempFileName();
        File.WriteAllText(Path, content);
    }

    public string Path { get; }

    public void Dispose() => File.Delete(Path);
}
