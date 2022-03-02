using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
namespace Jh.Abp.JhMenu
{
	/// <summary>
	/// 菜单
	/// </summary>
	public class MenuDto: ExtensibleFullAuditedEntityDto<System.Guid>
,IMultiTenant, IHasConcurrencyStamp
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
		 public virtual Guid? TenantId { get; set; }
        public virtual string ConcurrencyStamp { get; set; }
    }
}
