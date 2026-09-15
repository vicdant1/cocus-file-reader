namespace Cocus.FileReader.Tests;

public sealed class TextFileReaderTests
{
    private readonly TextFileReader _reader = new();

    [Fact]
    public void Read_ReturnsFileContent()
    {
        using var file = new TempFile("Hello, COCUS!");

        var content = _reader.Read(file.Path);

        Assert.Equal("Hello, COCUS!", content);
    }

    [Fact]
    public void Read_ThrowsWhenFileDoesNotExist()
    {
        var path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

        Assert.Throws<FileNotFoundException>(() => _reader.Read(path));
    }

    [Fact]
    public void Read_WithEncryption_ReturnsDecryptedContent()
    {
        using var file = new TempFile("!SUCOC ,olleH");
        var reader = new TextFileReader(new ReverseEncryption());

        var content = reader.Read(file.Path);

        Assert.Equal("Hello, COCUS!", content);
    }
}
