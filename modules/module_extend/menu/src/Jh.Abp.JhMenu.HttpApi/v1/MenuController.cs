using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;

namespace Jh.Abp.JhMenu.v1
{
    [Area(JhMenuRemoteServiceConsts.ModuleName)]
	[RemoteService(Name = JhMenuRemoteServiceConsts.RemoteServiceName)]
	[Route("api/v{apiVersion:apiVersion}/[controller]")]
	public class MenuController : JhMenuController, IMenuRemoteService
	{
		private readonly IMenuAppService MenuAppService;
		protected IDataFilter DataFilter => LazyServiceProvider.LazyGetRequiredService<IDataFilter>();

		public MenuController(IMenuAppService _MenuAppService)
		{
			MenuAppService = _MenuAppService;
		}

		[Authorize(JhMenuPermissions.Menus.Default)]
		[HttpGet]
		public virtual async Task<PagedResultDto<MenuDto>> GetListAsync([FromQuery] MenuRetrieveInputDto input)
		{
			using (DataFilter.Disable<ISoftDelete>())
			{
				return await MenuAppService.GetListAsync(input);
			}
		}

		[Authorize(JhMenuPermissions.Menus.Default)]
		[Route("all")]
		[HttpGet]
		public virtual async Task<ListResultDto<MenuDto>> GetEntitysAsync([FromQuery] MenuRetrieveInputDto inputDto)
		{
			return await MenuAppService.GetEntitysAsync(inputDto);
		}

		[Authorize(JhMenuPermissions.Menus.Detail)]
		[HttpGet("{id}")]
		public virtual async Task<Menu> GetAsync(System.Guid id)
		{
			return await MenuAppService.GetEntityAsync(id);
		}

		[Authorize(JhMenuPermissions.Menus.Create)]
		[HttpPost]
		public virtual async Task CreateAsync(MenuCreateInputDto input)
		{
			 await MenuAppService.CreateAsync(input,true);
		}

		[Authorize(JhMenuPermissions.Menus.Update)]
		[HttpPut("{id}")]
		public virtual async Task<MenuDto> UpdateAsync(System.Guid id, MenuUpdateInputDto input)
		{
			return await MenuAppService.UpdateAsync(id, input);
		}

		[Authorize(JhMenuPermissions.Menus.Update)]
		[HttpPut("Patch/{id}")]//兼容手机端，手机端不支持Patch
		[HttpPatch("{id}")]
		public virtual async Task UpdatePortionAsync(System.Guid id, MenuUpdateInputDto inputDto)
		{
			 await MenuAppService.UpdatePortionAsync(id, inputDto);
		}

		[Authorize(JhMenuPermissions.Menus.Delete)]
		[HttpDelete("{id}")]
		public virtual async Task DeleteAsync(System.Guid id)
		{
			 await MenuAppService.DeleteAsync(id);
		}

		[Authorize(JhMenuPermissions.Menus.BatchDelete)]
		[Route("keys")]
		[HttpDelete]
		public virtual async Task DeleteAsync([FromBody]System.Guid[] keys)
		{
			 await MenuAppService.DeleteAsync(keys);
		}

		[Authorize(JhMenuPermissions.Menus.Recover)]
		[HttpPatch]
		[HttpPut]
		[Route("{id}/Recover")]
		public async Task RecoverAsync(Guid id)
        {
			await MenuAppService.RecoverAsync(id);
		}
    }
}
