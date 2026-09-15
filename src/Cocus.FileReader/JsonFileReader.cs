using System.Text.Encodings.Web;
using System.Text.Json;

namespace Cocus.FileReader;

public sealed class JsonFileReader(IEncryption? encryption = null) : IFileReader
{
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public string Read(string path)
    {
        var content = File.ReadAllText(path);

        if (encryption is not null)
            content = encryption.Decrypt(content);

        using var document = JsonDocument.Parse(content);
        return JsonSerializer.Serialize(document.RootElement, Options);
    }
}
