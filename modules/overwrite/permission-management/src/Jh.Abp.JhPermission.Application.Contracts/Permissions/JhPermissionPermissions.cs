using Volo.Abp.Reflection;

namespace Jh.Abp.JhPermission.Permissions;

public class JhPermissionPermissions
{
    public const string GroupName = "JhPermission";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(JhPermissionPermissions));
    }
}
