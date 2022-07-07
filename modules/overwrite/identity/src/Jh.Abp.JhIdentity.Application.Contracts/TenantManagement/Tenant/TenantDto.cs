using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Jh.Abp.TenantManagement
{
    public class TenantDto : ExtensibleFullAuditedEntityDto<System.Guid>
, IHasConcurrencyStamp
    {
        public string Name { get; set; }
        public string ConcurrencyStamp { get; set; }
        //public virtual List<TenantConnectionString> ConnectionStrings { get; protected set; }
    }
}
