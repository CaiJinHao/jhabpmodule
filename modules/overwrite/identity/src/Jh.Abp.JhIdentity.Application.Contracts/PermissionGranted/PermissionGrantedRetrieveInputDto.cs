using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.MultiTenancy;

namespace Jh.Abp.JhPermission
{
    public class PermissionGrantedRetrieveInputDto : IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }
        public string[] PermissionNames { get; set; }
        public string ProviderName { get; set; } = RolePermissionValueProvider.ProviderName;
        public string ProviderKey { get; set; }
    }
}
