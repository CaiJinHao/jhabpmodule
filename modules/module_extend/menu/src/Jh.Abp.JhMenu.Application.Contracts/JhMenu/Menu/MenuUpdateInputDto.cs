using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
namespace Jh.Abp.JhMenu
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class MenuUpdateInputDto: 
ExtensibleObject,
IHasConcurrencyStamp,
IMethodDto<Menu>
, IMultiTenant
	{
		/// <summary>
		/// 菜单编号
		/// </summary>
		public String MenuCode { get; set; }
		/// <summary>
		/// 菜单名称
		/// </summary>
		public String MenuName { get; set; }
		/// <summary>
		/// 菜单图标
		/// </summary>
		public String MenuIcon { get; set; }
		/// <summary>
		/// 菜单排序
		/// </summary>
		public Int32? MenuSort { get; set; }
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
		public Int32? MenuPlatform { get; set; }
		/// <summary>
		/// 并发检测字段 必须和数据库中的值一样才会允许更新
		/// </summary>
		public string ConcurrencyStamp { get; set; }
		/// <summary>
		/// 是否删除
		/// </summary>
		public  bool IsDeleted { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<Menu> MethodInput { get; set; }
		public virtual Guid? TenantId { get; set; }
	}
}
