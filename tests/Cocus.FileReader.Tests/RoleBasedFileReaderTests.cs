namespace Cocus.FileReader.Tests;

public sealed class RoleBasedFileReaderTests
{
    [Fact]
    public void Read_ReturnsContentWhenAccessIsAllowed()
    {
        using var file = new TempFile("<catalog />");
        var reader = new RoleBasedFileReader(new XmlFileReader(), new SimpleAccessPolicy(), "admin");

        var content = reader.Read(file.Path);

        Assert.Equal("<catalog />", content);
    }

    [Fact]
    public void Read_ThrowsWhenAccessIsDenied()
    {
        using var file = new TempFile("<catalog />");
        var reader = new RoleBasedFileReader(new XmlFileReader(), new SimpleAccessPolicy(), "user");

        Assert.Throws<UnauthorizedAccessException>(() => reader.Read(file.Path));
    }
}
