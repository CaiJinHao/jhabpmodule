using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.MultiTenancy;
namespace Jh.Abp.JhMenu
{
    /// <summary>
    /// 角色菜单
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
