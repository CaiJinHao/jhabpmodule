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
    [RemoteService(Name = JhIdentityRemoteServiceConsts.RemoteServiceName)]
	[Area(JhIdentityRemoteServiceConsts.ModuleName)]
	[Route("api/v{apiVersion:apiVersion}/[controller]")]
	public class IdentityRoleController : JhIdentityController, Jh.Abp.JhIdentity.IJhIdentityRoleAppService
	{
		protected IOrganizationUnitAppService OrganizationUnitAppService => LazyServiceProvider.LazyGetRequiredService<IOrganizationUnitAppService>();
		public IDataFilter<ISoftDelete> DataFilterDelete { get; set; }
		protected Volo.Abp.Identity.IIdentityRoleAppService RoleAppService => LazyServiceProvider.LazyGetRequiredService<Volo.Abp.Identity.IIdentityRoleAppService>();
		protected IJhIdentityRoleAppService IdentityRoleAppService => LazyServiceProvider.LazyGetRequiredService<IJhIdentityRoleAppService>();

		[Authorize(IdentityPermissions.Roles.Create)]
		[HttpPost]
		public virtual async Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateInputDto input)
		{
			return await IdentityRoleAppService.CreateAsync(input);
		}

		[Authorize(IdentityPermissions.Roles.Default)]
		[HttpPost("roles")]
		public virtual async Task<Volo.Abp.Identity.IdentityRoleDto> CreateAsync(Volo.Abp.Identity.IdentityRoleCreateDto input)
		{
			//将该角色添加到所有组织
			var data = await RoleAppService.CreateAsync(input);
			await OrganizationUnitAppService.CreateByRoleAsync(data.Id);
			return data;
		}

		[Authorize(IdentityPermissions.Roles.Delete)]
		[HttpDelete]
		[Route("{id}")]
		public virtual Task DeleteAsync(Guid id)
		{
			return RoleAppService.DeleteAsync(id);
		}

		[Authorize(IdentityPermissions.Roles.Delete)]
		[Route("keys")]
		[HttpDelete]
		public virtual async Task DeleteAsync([FromBody] System.Guid[] keys)
		{
			await IdentityRoleAppService.DeleteAsync(keys);
		}

		[Authorize(IdentityPermissions.Roles.Update)]
		[HttpPut("{id}")]
		public virtual async Task<IdentityRoleDto> UpdateAsync(System.Guid id, IdentityRoleUpdateInputDto input)
		{
			return await IdentityRoleAppService.UpdateAsync(id, input);
		}

		[Authorize(IdentityPermissions.Roles.Update)]
		[HttpPatch("{id}")]
		public virtual async Task UpdatePortionAsync(System.Guid id, IdentityRoleUpdateInputDto inputDto)
		{
			await IdentityRoleAppService.UpdatePortionAsync(id, inputDto);
		}

		[Authorize(IdentityPermissions.Roles.Default)]
		[HttpGet]
		public virtual async Task<PagedResultDto<IdentityRoleDto>> GetListAsync([FromQuery] IdentityRoleRetrieveInputDto input)
		{
			using (DataFilterDelete.Disable())
			{
				return await IdentityRoleAppService.GetListAsync(input);
			}
		}

		[Authorize(IdentityPermissions.Roles.Default)]
		[Route("all")]
		[HttpGet]
		public virtual async Task<ListResultDto<IdentityRoleDto>> GetEntitysAsync([FromQuery] IdentityRoleRetrieveInputDto inputDto)
		{
			return await IdentityRoleAppService.GetEntitysAsync(inputDto);
		}

		[Authorize(IdentityPermissions.Roles.Default)]
		[HttpGet("{id}")]
		public virtual async Task<IdentityRoleDto> GetAsync(System.Guid id)
		{
			return await IdentityRoleAppService.GetAsync(id);
		}

		[Authorize(IdentityPermissions.Roles.Default)]
		[HttpGet]
		[Route("tree")]
		public virtual async Task<dynamic> GetTreeAsync(string name)
		{
			var datas = await IdentityRoleAppService.GetEntitysAsync(new IdentityRoleRetrieveInputDto() { Name = name });
			return new
			{
				items = datas.Items.Select(a => new { title = a.Name, id = a.Id, data = a, spread = true })
			};
		}

		[Authorize(IdentityPermissions.Roles.Default)]
		[HttpGet]
		[Route("select")]
		public virtual async Task<dynamic> GetSelectAsync(string name)
		{
			var datas = await IdentityRoleAppService.GetEntitysAsync(new IdentityRoleRetrieveInputDto() { Name = name });
			return new
			{
				items = datas.Items.Select(a => new { name = a.Name, value = a.Id })
			};
		}

	}
}
