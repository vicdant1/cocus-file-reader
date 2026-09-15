using System.Xml;

namespace Cocus.FileReader.Tests;

public sealed class XmlFileReaderTests
{
    private readonly XmlFileReader _reader = new();

    [Fact]
    public void Read_ReturnsXmlContent()
    {
        using var file = new TempFile("<catalog><item>Hello</item></catalog>");
        var expected = string.Join(Environment.NewLine, "<catalog>", "  <item>Hello</item>", "</catalog>");

        var content = _reader.Read(file.Path);

        Assert.Equal(expected, content);
    }

    [Fact]
    public void Read_ThrowsWhenXmlIsInvalid()
    {
        using var file = new TempFile("<catalog><item>Hello</catalog>");

        Assert.Throws<XmlException>(() => _reader.Read(file.Path));
    }
}
