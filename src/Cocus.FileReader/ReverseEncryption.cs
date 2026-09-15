namespace Cocus.FileReader;

public sealed class ReverseEncryption : IEncryption
{
    public string Decrypt(string content) => new(content.Reverse().ToArray());
}
