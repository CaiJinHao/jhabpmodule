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
        /// ��ȡ��ǰ��¼��ɫ��Ȩ�޵Ĳ˵���
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TreeDto>> GetMenusNavTreesAsync();

        /// <summary>
        /// ��ȡ���в˵�������Ȩ�޵��Զ�ѡ��
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TreeDto>> GetMenusTreesAsync(MenuRoleMapRetrieveInputDto input);
    }
}
