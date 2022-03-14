using Jh.Abp.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Jh.Abp.JhMenu.v1
{
    [Area(JhMenuRemoteServiceConsts.ModuleName)]
	[RemoteService(Name = JhMenuRemoteServiceConsts.RemoteServiceName)]
	[Route("api/v{apiVersion:apiVersion}/[controller]")]
	public class MenuRoleMapController : JhMenuController, IMenuRoleMapAppService
    {
		private readonly IMenuRoleMapAppService MenuRoleMapAppService;
		public MenuRoleMapController(IMenuRoleMapAppService _MenuRoleMapAppService)
		{
			MenuRoleMapAppService = _MenuRoleMapAppService;
		}

        [Authorize(JhMenuPermissions.MenuRoleMaps.Create)]
		[HttpPost]
        public async Task<MenuRoleMapDto> CreateAsync(MenuRoleMapCreateInputDto input)
        {
			return await MenuRoleMapAppService.CreateAsync(input);
        }

        [Authorize(JhMenuPermissions.MenuRoleMaps.Default)]
        [HttpGet("Trees")]
        public virtual async Task<IEnumerable<TreeDto>> GetMenusNavTreesAsync()
        {
            return await MenuRoleMapAppService.GetMenusNavTreesAsync();
        }

        [Authorize(JhMenuPermissions.MenuRoleMaps.Default)]
        [HttpGet("TreesAll")]
        public virtual async Task<IEnumerable<TreeDto>> GetMenusTreesAsync(MenuRoleMapRetrieveInputDto input)
        {
            return await MenuRoleMapAppService.GetMenusTreesAsync(input);
        }

        [Obsolete]
        [Authorize(JhMenuPermissions.MenuRoleMaps.Default)]
        [Route("keys")]
        [HttpDelete]
        public Task DeleteAsync(Guid[] keys)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        [Authorize(JhMenuPermissions.MenuRoleMaps.Default)]
        [HttpDelete("{id}")]
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        [Authorize(JhMenuPermissions.MenuRoleMaps.Default)]
        [HttpGet("{id}")]
        public Task<MenuRoleMapDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        [Authorize(JhMenuPermissions.MenuRoleMaps.Default)]
        [Route("all")]
        [HttpGet]
        public Task<ListResultDto<MenuRoleMapDto>> GetEntitysAsync(MenuRoleMapRetrieveInputDto inputDto)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        [Authorize(JhMenuPermissions.MenuRoleMaps.Default)]
        [HttpGet]
        public Task<PagedResultDto<MenuRoleMapDto>> GetListAsync(MenuRoleMapRetrieveInputDto input)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        [Authorize(JhMenuPermissions.MenuRoleMaps.Default)]
        [HttpPut("{id}")]
        public Task<MenuRoleMapDto> UpdateAsync(Guid id, MenuRoleMapUpdateInputDto input)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        [Authorize(JhMenuPermissions.MenuRoleMaps.Default)]
        [HttpPut("Patch/{id}")]
        [HttpPatch("{id}")]
        public Task UpdatePortionAsync(Guid id, MenuRoleMapUpdateInputDto inputDto)
        {
            throw new NotImplementedException();
        }
    }
}
