using System.Text.Encodings.Web;
using System.Text.Json;

namespace Cocus.FileReader;

public sealed class JsonFileReader : IFileReader
{
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public string Read(string path)
    {
        using var document = JsonDocument.Parse(File.ReadAllText(path));
        return JsonSerializer.Serialize(document.RootElement, Options);
    }
}
