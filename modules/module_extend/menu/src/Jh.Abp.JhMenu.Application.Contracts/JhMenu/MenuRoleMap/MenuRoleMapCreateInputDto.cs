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
	public class MenuRoleMapCreateInputDto
	{
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
