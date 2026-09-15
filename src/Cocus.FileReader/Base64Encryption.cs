using System.Text;

namespace Cocus.FileReader;

public sealed class Base64Encryption : IEncryption
{
    public string Decrypt(string content) => Encoding.UTF8.GetString(Convert.FromBase64String(content));
}
