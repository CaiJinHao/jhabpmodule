using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
namespace Jh.Abp.JhMenu
{
    /// <summary>
    /// 角色菜单
    /// </summary>
    public class MenuRoleMapRetrieveInputDto: PagedAndSortedResultRequestDto, IMethodDto<MenuRoleMap>
,IMultiTenant
	{
		/// <summary>
		/// 方法参数回调
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public MethodDto<MenuRoleMap> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }

		/// <summary>
		/// 菜单外键
		/// </summary>
		public Guid MenuId { get; set; }

		/// <summary>
		/// 角色外键
		/// </summary>
		public Guid RoleId { get; set; }
	}
}
