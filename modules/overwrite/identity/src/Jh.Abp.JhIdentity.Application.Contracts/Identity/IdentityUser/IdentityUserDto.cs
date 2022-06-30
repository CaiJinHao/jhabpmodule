using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
namespace Jh.Abp.JhIdentity
{
	[Serializable]
	public class IdentityUserDto: ExtensibleFullAuditedEntityDto<System.Guid>
,IHasConcurrencyStamp
,IMultiTenant
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
		public bool IsActive { get; set; }
		/// <summary>
		/// 并发标识
		/// </summary>
		public string ConcurrencyStamp { get; set; }
		 public virtual Guid? TenantId { get; set; }

		public Guid[] OrganizationUnitIds { get; set; }

		public Guid[] RoleIds { get; set; }
		public string[] Roles { get; set; }
		public string[] OrganizationUnits { get; set; }
	}
}
