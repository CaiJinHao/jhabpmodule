using Jh.Abp.Extensions;
using System;
using Jh.Abp.Application.Contracts;
using System.Threading.Tasks;

namespace Jh.Abp.JhMenu
{
	public interface IMenuRemoteService
		: IRequestRemoteService<Menu, MenuDto, MenuDto, System.Guid, MenuRetrieveInputDto, MenuCreateInputDto, MenuUpdateInputDto, MenuDeleteInputDto>
 , IMenuBaseAppService
	{
	}
}
