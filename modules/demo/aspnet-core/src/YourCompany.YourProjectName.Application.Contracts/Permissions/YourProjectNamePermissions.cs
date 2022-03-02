using Volo.Abp.Reflection;

namespace YourCompany.YourProjectName.Permissions;

public class YourProjectNamePermissions
{
    public const string GroupName = "YourProjectName";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(YourProjectNamePermissions));
    }
}
