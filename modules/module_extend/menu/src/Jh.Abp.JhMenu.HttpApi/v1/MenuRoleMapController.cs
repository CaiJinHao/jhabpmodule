using Jh.Abp.Application.Contracts.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using System.Threading;
using System.Collections.Generic;
using Jh.Abp.Common;

namespace Jh.Abp.JhMenu.v1
{
	[Area(JhMenuRemoteServiceConsts.ModuleName)]
	[RemoteService(Name = JhMenuRemoteServiceConsts.RemoteServiceName)]
	[Route("api/v{apiVersion:apiVersion}/[controller]")]
	public class MenuRoleMapController : JhMenuController, IMenuRoleMapRemoteService
	{
		private readonly IMenuRoleMapAppService MenuRoleMapAppService;
		public IDataFilter<ISoftDelete> dataFilter { get; set; }
		public MenuRoleMapController(IMenuRoleMapAppService _MenuRoleMapAppService)
		{
			MenuRoleMapAppService = _MenuRoleMapAppService;
		}

		[Authorize(JhAbpJhMenuPermissions.MenuRoleMaps.Create)]
		[HttpPost]
		public virtual async Task CreateByRoleAsync(MenuRoleMapCreateInputDto inputDto, bool autoSave = false, CancellationToken cancellationToken = default)
        {
			await MenuRoleMapAppService.CreateByRoleAsync(inputDto);
		}

		[Authorize(JhAbpJhMenuPermissions.MenuRoleMaps.Default)]
		[HttpGet("Trees")]
		public virtual async Task<IEnumerable<TreeDto>> GetMenusNavTreesAsync()
        {
            return await MenuRoleMapAppService.GetMenusNavTreesAsync();
		}

		[Authorize(JhAbpJhMenuPermissions.MenuRoleMaps.Default)]
		[HttpGet("TreesAll")]
		public virtual async Task<IEnumerable<TreeDto>> GetMenusTreesAsync(MenuRoleMapRetrieveInputDto input)
        {
            return await MenuRoleMapAppService.GetMenusTreesAsync(input);
		}
    }
}
