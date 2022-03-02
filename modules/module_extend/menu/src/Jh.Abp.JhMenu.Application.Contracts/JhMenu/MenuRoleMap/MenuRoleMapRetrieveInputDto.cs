using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Application.Dtos;
namespace Jh.Abp.JhMenu
{
	/// <summary>
	/// 菜单角色中间表
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