using Jh.Abp.Application.Contracts;
namespace Jh.Abp.JhMenu
{
    public interface IMenuAppService
		: ICrudApplicationService<Menu, MenuDto, MenuDto, System.Guid, MenuRetrieveInputDto, MenuCreateInputDto, MenuUpdateInputDto, MenuDeleteInputDto>
		, IMenuBaseAppService
	{
	}
}
