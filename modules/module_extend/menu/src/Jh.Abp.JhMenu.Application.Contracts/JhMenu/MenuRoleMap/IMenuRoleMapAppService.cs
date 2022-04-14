using Jh.Abp.Application.Contracts;
using Jh.Abp.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jh.Abp.JhMenu
{
    public interface IMenuRoleMapAppService
		: ICrudApplicationService<MenuRoleMap, MenuRoleMapDto, MenuRoleMapDto, System.Guid, MenuRoleMapRetrieveInputDto, MenuRoleMapCreateInputDto, MenuRoleMapUpdateInputDto, MenuRoleMapDeleteInputDto>
    {
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

        /// <summary>
        /// 获取当前登录用户导航菜单 antd pro 专用
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CurrentUserNavMenusDto>> GeCurrentUserNavMenusAsync();
    }
}
