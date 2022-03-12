using Jh.Abp.JhIdentity.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Jh.Abp.JhAuditLogging.Permissions
{
    public class JhAuditLoggingPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var AuditLoggingsGroup = context.AddGroup(JhAuditLoggingPermissions.GroupName, L("Permission:JhAuditLogging"));
            var AuditLoggingsPermission = AuditLoggingsGroup.AddPermission(JhAuditLoggingPermissions.AuditLoggings.Default, L("Permission:AuditLoggings"));
            AuditLoggingsPermission.AddChild(JhAuditLoggingPermissions.AuditLoggings.Detail, L("Permission:Detail"));
            AuditLoggingsPermission.AddChild(JhAuditLoggingPermissions.AuditLoggings.Delete, L("Permission:Delete"));
            AuditLoggingsPermission.AddChild(JhAuditLoggingPermissions.AuditLoggings.BatchDelete, L("Permission:BatchDelete"));
            AuditLoggingsPermission.AddChild(JhAuditLoggingPermissions.AuditLoggings.ManagePermissions, L("Permission:ManagePermissions"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<JhIdentityResource>(name);
        }
    }
}