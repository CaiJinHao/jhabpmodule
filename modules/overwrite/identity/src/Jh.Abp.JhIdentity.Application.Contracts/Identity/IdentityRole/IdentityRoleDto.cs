using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
namespace Jh.Abp.JhIdentity
{
	/// <summary>
	/// 
	/// </summary>
	public class IdentityRoleDto: ExtensibleEntityDto<System.Guid>
,IHasConcurrencyStamp
,IMultiTenant
	{
		/// <summary>
		/// 
		/// </summary>
		public String Name { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String NormalizedName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Boolean? IsDefault { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Boolean? IsStatic { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Boolean? IsPublic { get; set; }
		/// <summary>
		/// 并发标识
		/// </summary>
		public string ConcurrencyStamp { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
