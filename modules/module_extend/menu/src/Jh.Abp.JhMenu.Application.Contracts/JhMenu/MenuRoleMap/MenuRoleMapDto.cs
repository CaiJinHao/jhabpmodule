using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
namespace Jh.Abp.JhMenu
{
	/// <summary>
	/// 角色菜单
	/// </summary>
	public class MenuRoleMapDto: CreationAuditedEntityDto<System.Guid>
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
		 public virtual Guid? TenantId { get; set; }
	}
}
