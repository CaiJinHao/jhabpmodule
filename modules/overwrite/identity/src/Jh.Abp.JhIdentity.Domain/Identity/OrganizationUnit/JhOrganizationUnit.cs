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
    public class JhOrganizationUnit : OrganizationUnit, IMultiTenant
    {
        public JhOrganizationUnit(Guid id, string displayName, Guid? parentId = null, Guid? tenantId = null) : base(id, displayName, parentId, tenantId)
        {
        }

        protected JhOrganizationUnit() { }

        public Guid? LeaderId { get; set; }
        public string LeaderName { get; set; }
    }
}
