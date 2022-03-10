using Jh.Abp.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;

namespace Jh.Abp.JhMenu.v1
{
    [Area(JhMenuRemoteServiceConsts.ModuleName)]
	[RemoteService(Name = JhMenuRemoteServiceConsts.RemoteServiceName)]
	[Route("api/v{apiVersion:apiVersion}/[controller]")]
	public class MenuRoleMapController : JhMenuController, IMenuRoleMapRemoteService
	{
		private readonly IMenuRoleMapAppService MenuRoleMapAppService;
		public MenuRoleMapController(IMenuRoleMapAppService _MenuRoleMapAppService)
		{
			MenuRoleMapAppService = _MenuRoleMapAppService;
		}

		[Authorize(JhMenuPermissions.MenuRoleMaps.Create)]
		[HttpPost]
		public virtual async Task CreateByRoleAsync(MenuRoleMapCreateInputDto inputDto, bool autoSave = false, CancellationToken cancellationToken = default)
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
    }
}
