namespace Cocus.FileReader.Cli;

internal static class ImplementationDiscovery
{
    public static T[] FindAll<T>() where T : class =>
        typeof(T).Assembly
            .GetTypes()
            .Where(type => type is { IsClass: true, IsAbstract: false }
                && typeof(T).IsAssignableFrom(type)
                && type.GetConstructor(Type.EmptyTypes) is not null)
            .OrderBy(type => type.Name)
            .Select(type => (T)Activator.CreateInstance(type)!)
            .ToArray();
}
