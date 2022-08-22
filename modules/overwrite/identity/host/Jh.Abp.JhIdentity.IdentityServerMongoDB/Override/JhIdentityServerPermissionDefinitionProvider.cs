using Jh.Abp.JhIdentity.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Localization;
using Volo.Abp.SettingManagement;

namespace Jh.Abp.JhIdentity.Override
{
    public class JhIdentityServerPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var permissionManageHostFeatures = context.GetPermissionOrNull(FeatureManagementPermissions.ManageHostFeatures);
            if (permissionManageHostFeatures != null)
            {
                //只是用来控制按钮得
                permissionManageHostFeatures.IsEnabled = false;
            }

            var permissionEmailing = context.GetPermissionOrNull(SettingManagementPermissions.Emailing);
            if (permissionEmailing != null)
            {
                //EmailSettingsAppService
                permissionEmailing.IsEnabled = false;//用来设置邮件服务器得权限控制
            }
        }
    }
}
