using YourCompany.YourProjectName.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace YourCompany.YourProjectName.Permissions;

public class YourProjectNamePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(YourProjectNamePermissions.GroupName, L("Permission:YourProjectName"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<YourProjectNameResource>(name);
    }
}
