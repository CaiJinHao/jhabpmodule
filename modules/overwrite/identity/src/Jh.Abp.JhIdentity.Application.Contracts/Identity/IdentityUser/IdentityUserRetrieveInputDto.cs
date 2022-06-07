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
    public class IdentityUserRetrieveInputDto: PagedAndSortedResultRequestDto, IMethodDto<IdentityUser>
, IRetrieveDelete
	{
		/// <summary>
		/// 
		/// </summary>
		public String UserName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String NormalizedUserName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String Name { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String Surname { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String Email { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String NormalizedEmail { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Boolean? EmailConfirmed { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String PasswordHash { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String SecurityStamp { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Boolean? IsExternal { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String PhoneNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Boolean? PhoneNumberConfirmed { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Boolean? TwoFactorEnabled { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTimeOffset? LockoutEnd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Boolean? LockoutEnabled { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Int32? AccessFailedCount { get; set; }
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? Deleted { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		[System.Text.Json.Serialization.JsonIgnore]
		[Newtonsoft.Json.JsonIgnore]
		public MethodDto<IdentityUser> MethodInput { get; set; }
		public string OrganizationUnitCode { get; set; }
	}
}
