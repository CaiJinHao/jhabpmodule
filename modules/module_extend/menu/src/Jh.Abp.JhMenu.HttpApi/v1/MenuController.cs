using Jh.Abp.Application.Contracts.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using System.Linq;

namespace Jh.Abp.JhMenu.v1
{
	[RemoteService]
	[Route("api/v{apiVersion:apiVersion}/[controller]")]
	public class MenuController : JhMenuController, IMenuRemoteService
	{
		private readonly IMenuAppService MenuAppService;
		public IDataFilter<ISoftDelete> dataFilter { get; set; }

		public MenuController(IMenuAppService _MenuAppService)
		{
			MenuAppService = _MenuAppService;
		}

		[Authorize(JhAbpJhMenuPermissions.Menus.Default)]
		[HttpGet]
		public virtual async Task<PagedResultDto<MenuDto>> GetListAsync([FromQuery] MenuRetrieveInputDto input)
		{
			using (dataFilter.Disable())
			{
				return await MenuAppService.GetListAsync(input);
			}
		}

		[Authorize(JhAbpJhMenuPermissions.Menus.Default)]
		[Route("all")]
		[HttpGet]
		public virtual async Task<ListResultDto<MenuDto>> GetEntitysAsync([FromQuery] MenuRetrieveInputDto inputDto)
		{
			return await MenuAppService.GetEntitysAsync(inputDto);
		}

		[Authorize(JhAbpJhMenuPermissions.Menus.Detail)]
		[HttpGet("{id}")]
		public virtual async Task<Menu> GetAsync(System.Guid id)
		{
			return await MenuAppService.GetEntityAsync(id);
		}

		[Authorize(JhAbpJhMenuPermissions.Menus.Create)]
		[HttpPost]
		public virtual async Task CreateAsync(MenuCreateInputDto input)
		{
			 await MenuAppService.CreateAsync(input,true);
		}

		[Authorize(JhAbpJhMenuPermissions.Menus.Update)]
		[HttpPut("{id}")]
		public virtual async Task<MenuDto> UpdateAsync(System.Guid id, MenuUpdateInputDto input)
		{
			return await MenuAppService.UpdateAsync(id, input);
		}

		[Authorize(JhAbpJhMenuPermissions.Menus.PortionUpdate)]
		[HttpPatch("{id}")]
		public virtual async Task UpdatePortionAsync(System.Guid id, MenuUpdateInputDto inputDto)
		{
			 await MenuAppService.UpdatePortionAsync(id, inputDto);
		}

		[Authorize(JhAbpJhMenuPermissions.Menus.Delete)]
		[HttpDelete("{id}")]
		public virtual async Task DeleteAsync(System.Guid id)
		{
			 await MenuAppService.DeleteAsync(id);
		}

		[Authorize(JhAbpJhMenuPermissions.Menus.BatchDelete)]
		[Route("keys")]
		[HttpDelete]
		public virtual async Task DeleteAsync([FromBody]System.Guid[] keys)
		{
			 await MenuAppService.DeleteAsync(keys);
		}

		[Authorize(JhAbpJhMenuPermissions.Menus.Recover)]
		[HttpPatch]
		[Route("{id}/Deleted")]
		public virtual async Task UpdateDeletedAsync(System.Guid id, [FromBody] bool isDeleted)
		{
			using (dataFilter.Disable())
			{
				await MenuAppService.UpdatePortionAsync(id, new MenuUpdateInputDto()
				{
					MethodInput = new MethodDto<Menu>()
					{
						 CreateOrUpdateEntityAction = (entity) => entity.IsDeleted = isDeleted
					}
				});
			}
		}
    }
}
