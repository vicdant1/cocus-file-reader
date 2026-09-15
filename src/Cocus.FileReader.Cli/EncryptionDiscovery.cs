namespace Cocus.FileReader.Cli;

internal static class EncryptionDiscovery
{
    public static IEncryption[] FindAll() =>
        typeof(IEncryption).Assembly
            .GetTypes()
            .Where(type => type is { IsClass: true, IsAbstract: false }
                && typeof(IEncryption).IsAssignableFrom(type)
                && type.GetConstructor(Type.EmptyTypes) is not null)
            .OrderBy(type => type.Name)
            .Select(type => (IEncryption)Activator.CreateInstance(type)!)
            .ToArray();
}
