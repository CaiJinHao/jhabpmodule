using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.TenantManagement;

namespace Jh.Abp.JhIdentity.Permissions.TenantManagement
{
    public static class JhTenantManagementPermissions
    {
        public static class Tenants
        {
            public const string Default = TenantManagementPermissions.Tenants.Default;
            public const string Recover = Default + ".Recover";
        }
    }
}
