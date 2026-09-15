namespace Cocus.FileReader.Tests;

public sealed class Base64EncryptionTests
{
    private readonly Base64Encryption _encryption = new();

    [Fact]
    public void Decrypt_DecodesBase64Content()
    {
        var content = _encryption.Decrypt("SGVsbG8sIENPQ1VTIQ==");

        Assert.Equal("Hello, COCUS!", content);
    }

    [Fact]
    public void Decrypt_ThrowsWhenContentIsNotBase64()
    {
        Assert.Throws<FormatException>(() => _encryption.Decrypt("Hello, COCUS!"));
    }
}
