using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
namespace Jh.Abp.JhIdentity
{
    /// <summary>
    /// 
    /// </summary>
    public class IdentityRoleCreateInputDto: 
ExtensibleObject,
IHasConcurrencyStamp,
IMethodDto<IdentityRole>
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
		/// 并发检测字段 必须和数据库中的值一样才会允许更新
		/// </summary>
		public string ConcurrencyStamp { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		[System.Text.Json.Serialization.JsonIgnore]
		public MethodDto<IdentityRole> MethodInput { get; set; }
	}
}
