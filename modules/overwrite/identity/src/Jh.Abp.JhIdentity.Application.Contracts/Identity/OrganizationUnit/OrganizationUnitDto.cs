using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;

namespace Jh.Abp.JhIdentity
{
    /// <summary>
    /// 
    /// </summary>
    public class OrganizationUnitDto: ExtensibleFullAuditedEntityDto<System.Guid>,IMultiTenant
		, IHasConcurrencyStamp
	{
        /// <summary>
        /// 
        /// </summary>
        public Guid? ParentId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String Code { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String DisplayName { get; set; }
		 public virtual Guid? TenantId { get; set; }
		/// <summary>
		/// 并发标识
		/// </summary>
		public string ConcurrencyStamp { get; set; }

		public Guid[] RoleIds { get; set; }

		[System.Text.Json.Serialization.JsonIgnore]
		[Newtonsoft.Json.JsonIgnore]
		public virtual ICollection<OrganizationUnitRole> Roles { get; set; }

	}
}
