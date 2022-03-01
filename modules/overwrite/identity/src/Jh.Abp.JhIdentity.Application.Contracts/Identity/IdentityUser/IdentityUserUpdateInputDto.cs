using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;
using JetBrains.Annotations;
using Volo.Abp.Auditing;

namespace Jh.Abp.JhIdentity
{
	/// <summary>
	/// 
	/// </summary>
	public class IdentityUserUpdateInputDto:
IdentityUserCreateOrUpdateDto,
IHasConcurrencyStamp,
IMethodDto<IdentityUser>
,IMultiTenant
	{
		[DisableAuditing]
		[DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPasswordLength))]
		public string Password { get; set; }
		/// <summary>
		/// 是否删除
		/// </summary>
		public  bool IsDeleted { get; set; }
		/// <summary>
		/// 并发检测字段 必须和数据库中的值一样才会允许更新
		/// </summary>
		public string ConcurrencyStamp { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<IdentityUser> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}


	public class IdentityUserCreateOrUpdateDto: IdentityUserCreateOrUpdateDtoBase
	{
		public Guid[] OrganizationUnitIds { get; set; }
	}
}
