using Jh.Abp.Application.Contracts;

namespace Jh.Abp.JhMenu
{
    public interface IMenuRemoteService
		: IRequestRemoteService<Menu, MenuDto, MenuDto, System.Guid, MenuRetrieveInputDto, MenuCreateInputDto, MenuUpdateInputDto, MenuDeleteInputDto>
 , IMenuBaseAppService
	{
	}
}
