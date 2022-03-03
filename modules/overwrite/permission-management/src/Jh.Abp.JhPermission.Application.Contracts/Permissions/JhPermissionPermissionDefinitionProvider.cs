using Jh.Abp.JhPermission.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Jh.Abp.JhPermission.Permissions;

public class JhPermissionPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(JhPermissionPermissions.GroupName, L("Permission:JhPermission"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<JhPermissionResource>(name);
    }
}
