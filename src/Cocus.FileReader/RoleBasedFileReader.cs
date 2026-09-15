namespace Cocus.FileReader;

public sealed class RoleBasedFileReader(IFileReader inner, IAccessPolicy policy, string role) : IFileReader
{
    public string Read(string path) =>
        policy.CanRead(role, path)
            ? inner.Read(path)
            : throw new UnauthorizedAccessException($"Role '{role}' cannot read '{path}'.");
}
