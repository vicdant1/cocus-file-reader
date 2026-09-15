namespace Cocus.FileReader.Tests;

public sealed class SimpleAccessPolicyTests
{
    private readonly SimpleAccessPolicy _policy = new();

    [Theory]
    [InlineData("data/restricted/catalog.xml")]
    [InlineData("data/public/catalog.xml")]
    public void CanRead_AllowsAdminToReadAnyFile(string path)
    {
        Assert.True(_policy.CanRead("admin", path));
    }

    [Fact]
    public void CanRead_AllowsOtherRolesToReadPublicFiles()
    {
        Assert.True(_policy.CanRead("user", "data/public/catalog.xml"));
    }

    [Fact]
    public void CanRead_DeniesOtherRolesToReadRestrictedFiles()
    {
        Assert.False(_policy.CanRead("user", "data/restricted/catalog.xml"));
    }
}
