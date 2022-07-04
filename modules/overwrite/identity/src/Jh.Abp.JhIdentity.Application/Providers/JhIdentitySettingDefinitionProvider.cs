using Jh.Abp.JhIdentity.Localization;
using Volo.Abp.Account.Localization;
using Volo.Abp.Account.Settings;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Jh.Abp.JhIdentity
{
    public class JhIdentitySettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            var IsSelfRegistrationEnabled = context.GetOrNull(AccountSettingNames.IsSelfRegistrationEnabled);
            if (IsSelfRegistrationEnabled != null)
            {
                IsSelfRegistrationEnabled.DefaultValue = "false";
            }
        }
    }
}
