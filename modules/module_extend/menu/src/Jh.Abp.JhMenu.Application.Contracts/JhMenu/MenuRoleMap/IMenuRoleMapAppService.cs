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
        /// ��ȡ��ǰ��¼��ɫ��Ȩ�޵Ĳ˵���
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TreeDto>> GetMenusNavTreesAsync();

        /// <summary>
        /// ��ȡ���в˵�������Ȩ�޵��Զ�ѡ��
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TreeDto>> GetMenusTreesAsync(MenuRoleMapRetrieveInputDto input);

        /// <summary>
        /// ��ȡ��ǰ��¼�û������˵� antd pro ר��
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CurrentUserNavMenusDto>> GeCurrentUserNavMenusAsync();
    }
}
