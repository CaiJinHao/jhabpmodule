using Jh.Abp.Application.Contracts.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
namespace Jh.Abp.JhMenu.v1
{
	[RemoteService]
	[Route("api/v{apiVersion:apiVersion}/[controller]")]
	public class MenuRoleMapController : JhMenuController
	{
		private readonly IMenuRoleMapAppService MenuRoleMapAppService;
		public IDataFilter<ISoftDelete> dataFilter { get; set; }
		public MenuRoleMapController(IMenuRoleMapAppService _MenuRoleMapAppService)
		{
			MenuRoleMapAppService = _MenuRoleMapAppService;
		}
		[Authorize(JhAbpJhMenuPermissions.MenuRoleMaps.Default)]
		[HttpGet]
		public virtual async Task<PagedResultDto<MenuRoleMapDto>> GetListAsync([FromQuery] MenuRoleMapRetrieveInputDto input)
		{
			using (dataFilter.Disable())
			{
				return await MenuRoleMapAppService.GetListAsync(input);
			}
		}
		[Authorize(JhAbpJhMenuPermissions.MenuRoleMaps.Default)]
		[Route("all")]
		[HttpGet]
		public virtual async Task<ListResultDto<MenuRoleMapDto>> GetEntitysAsync([FromQuery] MenuRoleMapRetrieveInputDto inputDto)
		{
			return await MenuRoleMapAppService.GetEntitysAsync(inputDto);
		}
		[Authorize(JhAbpJhMenuPermissions.MenuRoleMaps.Detail)]
		[HttpGet("{id}")]
		public virtual async Task<MenuRoleMapDto> GetAsync(System.Guid id)
		{
			return await MenuRoleMapAppService.GetAsync(id);
		}
		[Authorize(JhAbpJhMenuPermissions.MenuRoleMaps.Create)]
		[HttpPost]
		public virtual async Task CreateAsync(MenuRoleMapCreateInputDto input)
		{
			 await MenuRoleMapAppService.CreateV2Async(input);
			 //await MenuRoleMapAppService.CreateAsync(input,true);
		}
		[Authorize(JhAbpJhMenuPermissions.MenuRoleMaps.BatchCreate)]
		[Route("items")]
		[HttpPost]
		public virtual async Task CreateAsync(MenuRoleMapCreateInputDto[] input)
		{
			 await MenuRoleMapAppService.CreateAsync(input);
		}
		[Authorize(JhAbpJhMenuPermissions.MenuRoleMaps.Update)]
		[HttpPut("{id}")]
		public virtual async Task<MenuRoleMapDto> UpdateAsync(System.Guid id, MenuRoleMapUpdateInputDto input)
		{
			return await MenuRoleMapAppService.UpdateAsync(id, input);
		}
		[Authorize(JhAbpJhMenuPermissions.MenuRoleMaps.PortionUpdate)]
		[HttpPatch("{id}")]
		public virtual async Task UpdatePortionAsync(System.Guid id, MenuRoleMapUpdateInputDto inputDto)
		{
			 await MenuRoleMapAppService.UpdatePortionAsync(id, inputDto);
		}
		[Authorize(JhAbpJhMenuPermissions.MenuRoleMaps.Delete)]
		[HttpDelete("{id}")]
		public virtual async Task DeleteAsync(System.Guid id)
		{
			 await MenuRoleMapAppService.DeleteAsync(id);
		}
		[Authorize(JhAbpJhMenuPermissions.MenuRoleMaps.BatchDelete)]
		[HttpDelete]
		public virtual async Task DeleteAsync(MenuRoleMapDeleteInputDto deleteInputDto)
		{
			 await MenuRoleMapAppService.DeleteAsync(deleteInputDto);
		}
		[Authorize(JhAbpJhMenuPermissions.MenuRoleMaps.BatchDelete)]
		[Route("keys")]
		[HttpDelete]
		public virtual async Task DeleteAsync([FromBody]System.Guid[] keys)
		{
			 await MenuRoleMapAppService.DeleteAsync(keys);
		}

		[Authorize(JhAbpJhMenuPermissions.MenuRoleMaps.Default)]
		[HttpGet("Trees")]
		public virtual async Task<dynamic> GetMenusNavTreesAsync()
		{
			var items = await MenuRoleMapAppService.GetMenusNavTreesAsync();
			return new { items };
		}

		[Authorize(JhAbpJhMenuPermissions.MenuRoleMaps.Default)]
		[HttpGet("TreesAll")]
		public virtual async Task<dynamic> GetMenusTreesAsync([FromQuery] MenuRoleMapRetrieveInputDto input)
		{
			var items = await MenuRoleMapAppService.GetMenusTreesAsync(input);
			return new { items };
		}
	}
}
