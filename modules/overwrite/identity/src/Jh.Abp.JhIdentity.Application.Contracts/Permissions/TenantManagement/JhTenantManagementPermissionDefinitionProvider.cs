using Jh.Abp.JhIdentity.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.TenantManagement;

namespace Jh.Abp.JhIdentity.Permissions.TenantManagement
{
    public class JhTenantManagementPermissionDefinitionProvider: PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var tenantManagementGroup = context.GetGroup(TenantManagementPermissions.GroupName);
            var tenantsPermission = tenantManagementGroup.GetPermissionOrNull(TenantManagementPermissions.Tenants.Default);
            //tenantsPermission.AddChild(JhIdentityPermissions.IdentityUsers.Detail, L("Permission:Detail"));
            //tenantsPermission.AddChild(JhIdentityPermissions.IdentityUsers.BatchDelete, L("Permission:BatchDelete"));
            tenantsPermission.AddChild(JhTenantManagementPermissions.Tenants.Recover, L("Permission:Recover"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<JhIdentityResource>(name);
        }
    }
}
