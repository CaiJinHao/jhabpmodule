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
	public class MenuController : JhMenuController, IMenuAppService
	{
		private readonly IMenuAppService MenuAppService;
		protected IDataFilter DataFilter => LazyServiceProvider.LazyGetRequiredService<IDataFilter>();

		public MenuController(IMenuAppService _MenuAppService)
		{
			MenuAppService = _MenuAppService;
		}

		[Authorize(JhMenuPermissions.Menus.Create)]
		[HttpPost]
		public virtual async Task<MenuDto> CreateAsync(MenuCreateInputDto input)
		{
			return await MenuAppService.CreateAsync(input);
		}

		[Authorize(JhMenuPermissions.Menus.Delete)]
        [Route("{id}")]
		[HttpDelete]
		public virtual async Task DeleteAsync(System.Guid id)
		{
			await MenuAppService.DeleteAsync(id);
		}

		[Authorize(JhMenuPermissions.Menus.BatchDelete)]
		[Route("keys")]
		[HttpDelete]
		public virtual async Task DeleteAsync([FromBody] System.Guid[] keys)
		{
			await MenuAppService.DeleteAsync(keys);
		}

		[Authorize(JhMenuPermissions.Menus.Update)]
        [Route("{id}")]
		[HttpPut]
		public virtual async Task<MenuDto> UpdateAsync(System.Guid id, MenuUpdateInputDto input)
		{
			return await MenuAppService.UpdateAsync(id, input);
		}

		[Authorize(JhMenuPermissions.Menus.Update)]
        [Route(("Patch/{id}"))]
		[HttpPut]
		public virtual async Task UpdatePortionAsync(System.Guid id, MenuUpdateInputDto inputDto)
		{
			await MenuAppService.UpdatePortionAsync(id, inputDto);
		}

		[Authorize(JhMenuPermissions.Menus.Recover)]
		[Route("{id}/Recover")]
		[HttpPut]
		public async Task RecoverAsync(Guid id)
		{
			await MenuAppService.RecoverAsync(id);
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
        [Route("{id}")]
		[HttpGet]
		public virtual async Task<MenuDto> GetAsync(System.Guid id)
		{
			return await MenuAppService.GetAsync(id);
		}

		[Authorize(JhMenuPermissions.Menus.Create)]
        [Route("MaxCode/{parentCode}")]
		[HttpGet]
		public async Task<string> GetMaxMenuCodeAsync(string parentCode)
        {
			return await MenuAppService.GetMaxMenuCodeAsync(parentCode);
        }
    }
}
