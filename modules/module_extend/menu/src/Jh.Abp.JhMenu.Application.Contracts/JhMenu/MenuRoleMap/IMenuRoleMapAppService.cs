using Jh.Abp.Common;
using Jh.Abp.Extensions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Jh.Abp.JhMenu
{
    public interface IMenuRoleMapAppService
		: ICrudApplicationService<MenuRoleMap, MenuRoleMapDto, MenuRoleMapDto, System.Guid, MenuRoleMapRetrieveInputDto, MenuRoleMapCreateInputDto, MenuRoleMapUpdateInputDto, MenuRoleMapDeleteInputDto>
	{
        Task<MenuRoleMap[]> CreateV2Async(MenuRoleMapCreateInputDto inputDto, bool autoSave = false, CancellationToken cancellationToken = default);

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
