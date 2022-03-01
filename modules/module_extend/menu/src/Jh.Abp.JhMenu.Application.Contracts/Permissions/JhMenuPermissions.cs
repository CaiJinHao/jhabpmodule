using Volo.Abp.Reflection;

namespace Jh.Abp.JhMenu.Permissions;

public class JhMenuPermissions
{
    public const string GroupName = "JhMenu";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(JhMenuPermissions));
    }
}
