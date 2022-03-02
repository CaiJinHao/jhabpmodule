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
	/// 菜单
	/// </summary>
	public class MenuCreateInputDto: 
ExtensibleObject,
IHasConcurrencyStamp,
IMethodDto<Menu>
, IMultiTenant
	{
		/// <summary>
		/// 菜单编号
		/// </summary>
		[Required]
		public String MenuCode { get; set; }
		/// <summary>
		/// 菜单名称
		/// </summary>
		[Required]
		public String MenuName { get; set; }
		/// <summary>
		/// 菜单图标
		/// </summary>
		[Required]
		public String MenuIcon { get; set; }
		/// <summary>
		/// 菜单排序
		/// </summary>
		[Required]
		public Int32 MenuSort { get; set; }
		/// <summary>
		/// 菜单上级菜单编号
		/// </summary>
		public String MenuParentCode { get; set; }
		/// <summary>
		/// 菜单导航路径
		/// </summary>
		public String MenuUrl { get; set; }
		/// <summary>
		/// 菜单描述
		/// </summary>
		public String MenuDescription { get; set; }
		/// <summary>
		/// 菜单所属平台
		/// </summary>
		[Required]
		public Int32 MenuPlatform { get; set; }
		/// <summary>
		/// 并发检测字段 必须和数据库中的值一样才会允许更新
		/// </summary>
		public string ConcurrencyStamp { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<Menu> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }

		/// <summary>
		/// 角色ID列表
		/// </summary>
		public Guid[] RoleIds { get; set; }
	}
}
