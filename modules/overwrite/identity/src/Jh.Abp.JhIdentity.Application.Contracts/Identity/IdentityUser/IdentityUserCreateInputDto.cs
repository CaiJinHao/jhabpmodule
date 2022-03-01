using System;
using System.ComponentModel.DataAnnotations;
using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;
using Volo.Abp.Auditing;
using JetBrains.Annotations;

namespace Jh.Abp.JhIdentity
{
	/// <summary>
	/// 
	/// </summary>
	public class IdentityUserCreateInputDto:
IdentityUserCreateOrUpdateDto,
IHasConcurrencyStamp,
IMethodDto<IdentityUser>
,IMultiTenant
	{
		[DisableAuditing]
		[Required]
		[DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPasswordLength))]
		public string Password { get; set; }
		/// <summary>
		/// 并发检测字段 必须和数据库中的值一样才会允许更新
		/// </summary>
		public string ConcurrencyStamp { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<IdentityUser> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }

		public Guid[] RoleIds { get; set; }
	}
}
