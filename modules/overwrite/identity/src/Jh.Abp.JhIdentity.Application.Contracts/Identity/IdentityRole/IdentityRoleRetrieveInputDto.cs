using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Identity;
using Volo.Abp.Application.Dtos;
namespace Jh.Abp.JhIdentity
{
	/// <summary>
	/// 
	/// </summary>
	public class IdentityRoleRetrieveInputDto: PagedAndSortedResultRequestDto, IMethodDto<IdentityRole>
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
		/// 方法参数回调
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public MethodDto<IdentityRole> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
