using Jh.Abp.Extensions;
using System;
namespace Jh.Abp.JhMenu
{
	public interface IMenuAppService
		: ICrudApplicationService<Menu, MenuDto, MenuDto, System.Guid, MenuRetrieveInputDto, MenuCreateInputDto, MenuUpdateInputDto, MenuDeleteInputDto>
	{
	}
}
