using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;

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
		/// ??????ʶ
		/// </summary>
		public string ConcurrencyStamp { get; set; }
	}
}
