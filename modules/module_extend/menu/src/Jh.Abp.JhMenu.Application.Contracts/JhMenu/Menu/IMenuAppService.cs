using Jh.Abp.Application.Contracts;
using System.Threading.Tasks;

namespace Jh.Abp.JhMenu
{
    public interface IMenuAppService
		: ICrudApplicationService<Menu, MenuDto, MenuDto, System.Guid, MenuRetrieveInputDto, MenuCreateInputDto, MenuUpdateInputDto, MenuDeleteInputDto>
	{
		Task RecoverAsync(System.Guid id);
		Task<string> GetMaxMenuCodeAsync(string parentCode);
	}
}
