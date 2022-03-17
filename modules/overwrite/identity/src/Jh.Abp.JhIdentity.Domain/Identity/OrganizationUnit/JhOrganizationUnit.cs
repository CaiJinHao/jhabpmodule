using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;

namespace Jh.Abp.JhIdentity
{
    /// <summary>
    /// 只能用来查询
    /// </summary>
    public class JhOrganizationUnit : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        protected JhOrganizationUnit() { }
        public virtual Guid? TenantId { get; protected set; }
        public virtual Guid? ParentId { get; internal set; }
        public virtual string Code { get; internal set; }
        public virtual string DisplayName { get; set; }


        public virtual Guid? LeaderId { get; set; }
        public virtual string LeaderName { get; set; }
    }
}
