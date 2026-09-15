namespace Cocus.FileReader;

public interface IAccessPolicy
{
    bool CanRead(string role, string path);
}
