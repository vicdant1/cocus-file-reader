using System.Text.Json;

namespace Cocus.FileReader.Tests;

public sealed class JsonFileReaderTests
{
    private readonly JsonFileReader _reader = new();

    [Fact]
    public void Read_ReturnsJsonContent()
    {
        using var file = new TempFile("""{"title":"Mensagem"}""");
        var expected = string.Join(Environment.NewLine, "{", "  \"title\": \"Mensagem\"", "}");

        var content = _reader.Read(file.Path);

        Assert.Equal(expected, content);
    }

    [Fact]
    public void Read_PreservesNonAsciiCharacters()
    {
        using var file = new TempFile("""{"author":"Álvaro de Campos"}""");

        var content = _reader.Read(file.Path);

        Assert.Contains("Álvaro de Campos", content);
    }

    [Fact]
    public void Read_ThrowsWhenJsonIsInvalid()
    {
        using var file = new TempFile("""{"title":""");

        Assert.ThrowsAny<JsonException>(() => _reader.Read(file.Path));
    }
}
