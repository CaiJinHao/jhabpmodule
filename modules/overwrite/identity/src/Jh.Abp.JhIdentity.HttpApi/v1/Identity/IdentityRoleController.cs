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
		[HttpPost("roles")]
		public virtual async Task<Volo.Abp.Identity.IdentityRoleDto> CreateAsync(Volo.Abp.Identity.IdentityRoleCreateDto input)
		{
			//将该角色添加到所有组织
			var data = await RoleAppService.CreateAsync(input);
			await OrganizationUnitAppService.CreateByRoleAsync(data.Id);
			return data;
		}

		[Authorize(IdentityPermissions.Roles.Create)]
		[HttpPost]
		public Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateInputDto input)
		{
			throw new NotImplementedException();
		}

		[Authorize(IdentityPermissions.Roles.Delete)]
		[HttpDelete]
		[Route("{id}")]
		public virtual Task DeleteAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		[Authorize(IdentityPermissions.Roles.Delete)]
		[Route("keys")]
		[HttpDelete]
		public virtual  Task DeleteAsync([FromBody] System.Guid[] keys)
		{
			throw new NotImplementedException();
		}

		[Authorize(IdentityPermissions.Roles.Update)]
		[HttpPut("{id}")]
		public virtual  Task<IdentityRoleDto> UpdateAsync(System.Guid id, IdentityRoleUpdateInputDto input)
		{
			throw new NotImplementedException();
		}

		[Authorize(IdentityPermissions.Roles.Update)]
		[HttpPatch("{id}")]
		public virtual  Task UpdatePortionAsync(System.Guid id, IdentityRoleUpdateInputDto inputDto)
		{
			throw new NotImplementedException();
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
                items = datas.Items.Where(a => a.Name != JhIdentity.JhIdentityConsts.AdminRoleName).Select(a => new { title = a.Name, id = a.Id, data = a, spread = true })
            };
        }

		[Authorize(IdentityPermissions.Roles.Default)]
		[HttpGet]
		[Route("options")]
		public virtual async Task<ListResultDto<OptionDto<Guid>>> GetOptionsAsync(string name)
		{
			return await IdentityRoleAppService.GetOptionsAsync(name);
		}

		[AllowAnonymous]
		[HttpGet("AdminRoleId")]
		public async Task<Guid?> GetAdminRoleIdAsync()
        {
            return await IdentityRoleAppService.GetAdminRoleIdAsync();
		}
    }
}
