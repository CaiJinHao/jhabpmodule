using Jh.Abp.Common;
using Jh.Abp.Extensions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Jh.Abp.JhMenu
{
    public interface IMenuRoleMapAppService
		: ICrudApplicationService<MenuRoleMap, MenuRoleMapDto, MenuRoleMapDto, System.Guid, MenuRoleMapRetrieveInputDto, MenuRoleMapCreateInputDto, MenuRoleMapUpdateInputDto, MenuRoleMapDeleteInputDto>
        ,IMenuRoleMapBaseAppService
    {

    }
}
