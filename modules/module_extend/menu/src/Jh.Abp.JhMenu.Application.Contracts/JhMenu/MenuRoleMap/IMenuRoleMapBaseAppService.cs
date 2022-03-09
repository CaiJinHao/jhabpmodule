using Jh.Abp.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
namespace Jh.Abp.JhMenu
{
	public interface IMenuRoleMapBaseAppService
	{
        //用于添加与RemoteService公共的方法
        Task CreateByRoleAsync(MenuRoleMapCreateInputDto inputDto, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取当前登录角色有权限的菜单树
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TreeDto>> GetMenusNavTreesAsync();

        /// <summary>
        /// 获取所有菜单树，有权限的自动选中
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TreeDto>> GetMenusTreesAsync(MenuRoleMapRetrieveInputDto input);
    }
}
