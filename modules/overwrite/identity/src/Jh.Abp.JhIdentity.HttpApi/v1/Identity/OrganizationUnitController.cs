using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity.v1
{
    /// <summary>
    /// 组织管理
    /// </summary>
    [RemoteService(Name = JhIdentityRemoteServiceConsts.RemoteServiceName)]
	[Area(JhIdentityRemoteServiceConsts.ModuleName)]
	[Route("api/v{apiVersion:apiVersion}/[controller]")]
	public class OrganizationUnitController : JhIdentityController
	{
		private readonly IOrganizationUnitAppService OrganizationUnitAppService;
		public IDataFilter<ISoftDelete> dataFilter { get; set; }
		public OrganizationUnitController(IOrganizationUnitAppService _OrganizationUnitAppService)
		{
			OrganizationUnitAppService = _OrganizationUnitAppService;
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Create)]
		[HttpPost]
		public virtual async Task CreateAsync(OrganizationUnitCreateInputDto input)
		{
			await OrganizationUnitAppService.CreateAsync(input);
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Delete)]
		[HttpDelete("{id}")]
		public virtual async Task DeleteAsync(System.Guid id)
		{
			await OrganizationUnitAppService.DeleteAsync(id);
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.BatchDelete)]
		[Route("keys")]
		[HttpDelete]
		public virtual async Task DeleteAsync([FromBody] System.Guid[] keys)
		{
			await OrganizationUnitAppService.DeleteAsync(keys);
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Update)]
		[HttpPut("{id}")]
		public virtual async Task<OrganizationUnitDto> UpdateAsync(System.Guid id, OrganizationUnitUpdateInputDto input)
		{
			return await OrganizationUnitAppService.UpdateAsync(id, input);
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.PortionUpdate)]
		[HttpPatch("{id}")]
		[HttpPut("Patch/{id}")]
		public virtual async Task UpdatePortionAsync(System.Guid id, OrganizationUnitUpdateInputDto inputDto)
		{
			await OrganizationUnitAppService.UpdatePortionAsync(id, inputDto);
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Recover)]
		[HttpPatch]
		[HttpPut]
		[Route("{id}/Deleted")]
		public virtual async Task UpdateDeletedAsync(System.Guid id)
		{
			using (dataFilter.Disable())
			{
				await OrganizationUnitAppService.RecoverAsync(id);
			}
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Default)]
		[HttpGet]
		public virtual async Task<PagedResultDto<OrganizationUnitDto>> GetListAsync([FromQuery] OrganizationUnitRetrieveInputDto input)
		{
			using (dataFilter.Disable())
			{
				return await OrganizationUnitAppService.GetListAsync(input);
			}
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Default)]
		[Route("all")]
		[HttpGet]
		public virtual async Task<ListResultDto<OrganizationUnitDto>> GetEntitysAsync([FromQuery] OrganizationUnitRetrieveInputDto inputDto)
		{
			return await OrganizationUnitAppService.GetEntitysAsync(inputDto);
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Detail)]
		[HttpGet("{id}")]
		public virtual async Task<OrganizationUnitDto> GetAsync(System.Guid id)
		{
			return await OrganizationUnitAppService.GetAsync(id);
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Default)]
		[HttpGet("Trees")]
		public virtual async Task<dynamic> GetOrganizationTreeAsync()
		{
			var items = await OrganizationUnitAppService.GetOrganizationTreeAsync();
			return new { items };
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Default)]
		[HttpGet]
		[Route("select")]
		public virtual async Task<dynamic> GetSelectAsync(string name)
		{
			var datas = await OrganizationUnitAppService.GetEntitysAsync(new OrganizationUnitRetrieveInputDto() { DisplayName = name });
			return new
			{
				items = datas.Items.Select(a => new { name = a.DisplayName, value = a.Id })
			};
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Default)]
		[HttpGet]
		[Route("{id}/roles")]
		public virtual async Task<dynamic> GetRolesByOrgAsync(Guid id)
		{
			var datas = await OrganizationUnitAppService.GetRolesAsync(id);
			return new
			{
				items = datas.Select(a => new { name = a.Name, value = a.Id })
			};
		}
	}
}
