using Jh.Abp.JhMenu.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Jh.Abp.JhMenu.Permissions;

public class JhMenuPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(JhMenuPermissions.GroupName, L("Permission:JhMenu"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<JhMenuResource>(name);
    }
}
