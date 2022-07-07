using Jh.Abp.JhIdentity.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Jh.Abp.JhIdentity.Permissions.TenantManagement
{
    public class JhTenantManagementPermissionDefinitionProvider: PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var tenantManagementGroup = context.GetGroup(TenantManagementPermissions.GroupName, L("Permission:TenantManagement"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<JhIdentityResource>(name);
        }
    }
}
