using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.MultiTenancy;

namespace Jh.Abp.JhPermission
{
    public class PermissionGrantedDto : IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }
        public string Name { get; set; }
        public bool Granted { get; set; }
    }
}
