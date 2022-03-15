using Volo.Abp.Reflection;

namespace Jh.Abp.Pay.Permissions;

public class PayPermissions
{
    public const string GroupName = "Pay";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(PayPermissions));
    }
}
