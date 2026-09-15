namespace Cocus.FileReader;

public sealed class SimpleAccessPolicy : IAccessPolicy
{
    private const string AdminRole = "admin";
    private const string PublicDirectory = "public";

    public bool CanRead(string role, string path) =>
        role.Equals(AdminRole, StringComparison.OrdinalIgnoreCase)
        || PublicDirectory.Equals(Path.GetFileName(Path.GetDirectoryName(Path.GetFullPath(path))), StringComparison.OrdinalIgnoreCase);
}
