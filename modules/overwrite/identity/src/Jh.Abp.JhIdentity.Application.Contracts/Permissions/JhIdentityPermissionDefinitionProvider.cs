using Jh.Abp.JhIdentity.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Jh.Abp.JhIdentity.Permissions;

public class JhIdentityPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(JhIdentityPermissions.GroupName, L("Permission:JhIdentity"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<JhIdentityResource>(name);
    }
}
