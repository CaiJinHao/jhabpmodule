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
		public virtual async Task CreateByRoleAsync(MenuRoleMapCreateInputDto inputDto)
        {
			await MenuRoleMapAppService.CreateByRoleAsync(inputDto);
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

        public Task<MenuRoleMapDto> CreateAsync(MenuRoleMapCreateInputDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid[] keys)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<MenuRoleMapDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ListResultDto<MenuRoleMapDto>> GetEntitysAsync(MenuRoleMapRetrieveInputDto inputDto)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<MenuRoleMapDto>> GetListAsync(MenuRoleMapRetrieveInputDto input)
        {
            throw new NotImplementedException();
        }

        public Task<MenuRoleMapDto> UpdateAsync(Guid id, MenuRoleMapUpdateInputDto input)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePortionAsync(Guid id, MenuRoleMapUpdateInputDto inputDto)
        {
            throw new NotImplementedException();
        }
    }
}
