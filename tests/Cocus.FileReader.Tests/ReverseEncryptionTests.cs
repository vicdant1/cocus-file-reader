namespace Cocus.FileReader.Tests;

public sealed class ReverseEncryptionTests
{
    [Fact]
    public void Decrypt_ReversesContent()
    {
        var encryption = new ReverseEncryption();

        var content = encryption.Decrypt("!SUCOC ,olleH");

        Assert.Equal("Hello, COCUS!", content);
    }
}
