using Jh.Abp.Common;
using Jh.Abp.Common.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
	public class OrganizationUnitController : JhIdentityController, IOrganizationUnitAppService
	{
		private readonly IOrganizationUnitAppService OrganizationUnitAppService;
		public IDataFilter<ISoftDelete> DataFilterDelete { get; set; }
		public OrganizationUnitController(IOrganizationUnitAppService _OrganizationUnitAppService)
		{
			OrganizationUnitAppService = _OrganizationUnitAppService;
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Create)]
		[HttpPost]
		public virtual async Task<OrganizationUnitDto> CreateAsync(OrganizationUnitCreateInputDto input)
		{
			return await OrganizationUnitAppService.CreateAsync(input);
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Delete)]
		[Route("{id}")]
		[HttpDelete]
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
		[Route("{id}")]
		[HttpPut]
		public virtual async Task<OrganizationUnitDto> UpdateAsync(System.Guid id, OrganizationUnitUpdateInputDto input)
		{
			return await OrganizationUnitAppService.UpdateAsync(id, input);
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Update)]
		[Route("Patch/{id}")]
		[HttpPut]
		public virtual async Task UpdatePortionAsync(System.Guid id, OrganizationUnitUpdateInputDto inputDto)
		{
			await OrganizationUnitAppService.UpdatePortionAsync(id, inputDto);
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Recover)]
		[Route("{id}/Recover")]
		[HttpPut]
		public async Task RecoverAsync(Guid id)
		{
			await OrganizationUnitAppService.RecoverAsync(id);
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Default)]
		[HttpGet]
		public virtual async Task<PagedResultDto<OrganizationUnitDto>> GetListAsync([FromQuery] OrganizationUnitRetrieveInputDto input)
		{
			using (DataFilterDelete.Disable())
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
		[Route("{id}")]
		[HttpGet]
		public virtual async Task<OrganizationUnitDto> GetAsync(System.Guid id)
		{
			return await OrganizationUnitAppService.GetAsync(id);
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Default)]
		[Route("{id}/roles")]
		[HttpGet]
		public virtual async Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
		{
			return await OrganizationUnitAppService.GetRolesAsync(id);
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Default)]
		[Route("Trees")]
		[HttpGet]
		public virtual async Task<ListResultDto<TreeAntdDto>> GetOrganizationTreeAsync()
		{
			return await OrganizationUnitAppService.GetOrganizationTreeAsync();
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Default)]
		[Route("options")]
		[HttpGet]
		public virtual async Task<ListResultDto<OptionDto<Guid>>> GetOptionsAsync(string name)
		{
			return await OrganizationUnitAppService.GetOptionsAsync(name);
		}

		[Authorize(JhIdentityPermissions.OrganizationUnits.Default)]
		[Route("{id}/Members")]
		[HttpGet]
		public async Task<ListResultDto<IdentityUserDto>> GetMembersAsync(Guid id)
        {
			return await OrganizationUnitAppService.GetMembersAsync(id);
        }

		[Authorize(JhIdentityPermissions.OrganizationUnits.Create)]
		[Route("Role/{roleId}")]
		[HttpGet]
		public Task CreateByRoleAsync(Guid roleId)
        {
            throw new NotImplementedException();
        }
    }
}
