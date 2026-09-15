namespace Cocus.FileReader.Tests;

public sealed class RoleBasedFileReaderTests
{
    [Fact]
    public void Read_ReturnsXmlContentWhenAccessIsAllowed()
    {
        using var file = new TempFile("<catalog />");
        var reader = new RoleBasedFileReader(new XmlFileReader(), new SimpleAccessPolicy(), "admin");

        var content = reader.Read(file.Path);

        Assert.Equal("<catalog />", content);
    }

    [Fact]
    public void Read_ThrowsWhenXmlAccessIsDenied()
    {
        using var file = new TempFile("<catalog />");
        var reader = new RoleBasedFileReader(new XmlFileReader(), new SimpleAccessPolicy(), "user");

        Assert.Throws<UnauthorizedAccessException>(() => reader.Read(file.Path));
    }

    [Fact]
    public void Read_ReturnsTextContentWhenAccessIsAllowed()
    {
        using var file = new TempFile("Hello, COCUS!");
        var reader = new RoleBasedFileReader(new TextFileReader(), new SimpleAccessPolicy(), "admin");

        var content = reader.Read(file.Path);

        Assert.Equal("Hello, COCUS!", content);
    }

    [Fact]
    public void Read_ThrowsWhenTextAccessIsDenied()
    {
        using var file = new TempFile("Hello, COCUS!");
        var reader = new RoleBasedFileReader(new TextFileReader(), new SimpleAccessPolicy(), "user");

        Assert.Throws<UnauthorizedAccessException>(() => reader.Read(file.Path));
    }

    [Fact]
    public void Read_ReturnsJsonContentWhenAccessIsAllowed()
    {
        using var file = new TempFile("[]");
        var reader = new RoleBasedFileReader(new JsonFileReader(), new SimpleAccessPolicy(), "admin");

        var content = reader.Read(file.Path);

        Assert.Equal("[]", content);
    }

    [Fact]
    public void Read_ThrowsWhenJsonAccessIsDenied()
    {
        using var file = new TempFile("[]");
        var reader = new RoleBasedFileReader(new JsonFileReader(), new SimpleAccessPolicy(), "user");

        Assert.Throws<UnauthorizedAccessException>(() => reader.Read(file.Path));
    }
}
