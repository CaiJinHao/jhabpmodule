using System;
using System.ComponentModel.DataAnnotations;
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
