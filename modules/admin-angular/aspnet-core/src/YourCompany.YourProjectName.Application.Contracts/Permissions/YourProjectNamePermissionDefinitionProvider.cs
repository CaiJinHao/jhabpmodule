using YourCompany.YourProjectName.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace YourCompany.YourProjectName.Permissions;

public class YourProjectNamePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(YourProjectNamePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(YourProjectNamePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<YourProjectNameResource>(name);
    }
}
