using Jh.Abp.JhIdentity.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Jh.Abp.SettingManagement.Permissions
{
    public class JhSettingManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var JhSettingManagementPermissionGroup = context.GetGroup(JhSettingManagementPermissions.GroupName);
            var JhSettingManagementPermission = JhSettingManagementPermissionGroup.AddPermission(JhSettingManagementPermissions.Settings.Default, L("Permission:Settings"));
            JhSettingManagementPermission.AddChild(JhSettingManagementPermissions.Settings.Update, L("Permission:Edit"));
            JhSettingManagementPermission.AddChild(JhSettingManagementPermissions.Settings.ManagePermissions, L("Permission:ManagePermissions"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<JhIdentityResource>(name);
        }
    }
}