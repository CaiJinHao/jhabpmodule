using System;
using System.ComponentModel.DataAnnotations;
using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
namespace Jh.Abp.JhMenu
{
	/// <summary>
	/// 角色菜单
	/// </summary>
	public class MenuRoleMapCreateInputDto: 
IMethodDto<MenuRoleMap>
,IMultiTenant
	{
		/// <summary>
		/// 菜单Id
		/// </summary>
		[Required]
		public Guid MenuId { get; set; }
		/// <summary>
		/// 用户角色
		/// </summary>
		[Required]
		public Guid RoleId { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<MenuRoleMap> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }

		/// <summary>
		/// 菜单外键
		/// </summary>
		[Required]
		public Guid[] MenuIds { get; set; }

		/// <summary>
		/// 角色外键
		/// </summary>
		[Required]
		public Guid[] RoleIds { get; set; }
	}
}
