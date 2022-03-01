using Volo.Abp.Reflection;

namespace Jh.Abp.JhIdentity.Permissions;

public class JhIdentityPermissions
{
    public const string GroupName = "JhIdentity";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(JhIdentityPermissions));
    }
}
