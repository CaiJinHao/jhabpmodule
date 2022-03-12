using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
namespace Jh.Abp.JhIdentity
{
    /// <summary>
    /// 
    /// </summary>
    public class IdentityRoleRetrieveInputDto: PagedAndSortedResultRequestDto, IMethodDto<IdentityRole>
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
	}
}
