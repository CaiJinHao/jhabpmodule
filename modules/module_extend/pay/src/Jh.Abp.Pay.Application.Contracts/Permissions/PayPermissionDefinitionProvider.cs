using Jh.Abp.Pay.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Jh.Abp.Pay.Permissions;

public class PayPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PayPermissions.GroupName, L("Permission:Pay"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PayResource>(name);
    }
}
