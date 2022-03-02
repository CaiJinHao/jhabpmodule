using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
using Volo.Abp.ObjectExtending;
namespace Jh.Abp.JhMenu
{
	/// <summary>
	/// 菜单角色中间表
	/// </summary>
	public class MenuRoleMapUpdateInputDto: 
IMethodDto<MenuRoleMap>
,IMultiTenant
	{
		/// <summary>
		/// 菜单Id
		/// </summary>
		public Guid? MenuId { get; set; }
		/// <summary>
		/// 用户角色
		/// </summary>
		public Guid? RoleId { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<MenuRoleMap> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}