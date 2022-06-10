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
        [Route("roles")]
		[HttpPost]
		public virtual async Task<Volo.Abp.Identity.IdentityRoleDto> CreateAsync(Volo.Abp.Identity.IdentityRoleCreateDto input)
		{
			//���ý�ɫ��ӵ�������֯
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
		[Route("{id}")]
		[HttpDelete]
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
        [Route("{id}")]
		[HttpPut]
		public virtual  Task<IdentityRoleDto> UpdateAsync(System.Guid id, IdentityRoleUpdateInputDto input)
		{
			throw new NotImplementedException();
		}

		[Authorize(IdentityPermissions.Roles.Update)]
        [Route("Patch/{id}")]
		[HttpPut]
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
        [Route("{id}")]
		[HttpGet]
		public virtual async Task<IdentityRoleDto> GetAsync(System.Guid id)
		{
			return await IdentityRoleAppService.GetAsync(id);
		}

		[Authorize]
		[Route("options")]
		[HttpGet]
		public virtual async Task<ListResultDto<OptionDto<Guid>>> GetOptionsAsync(string name)
		{
			return await IdentityRoleAppService.GetOptionsAsync(name);
		}

		[AllowAnonymous]
        [Route("AdminRoleId")]
		[HttpGet]
		public async Task<Guid?> GetAdminRoleIdAsync()
        {
            return await IdentityRoleAppService.GetAdminRoleIdAsync();
		}

		[Authorize]
		[Route("Trees")]
		[HttpGet]
		public  async Task<ListResultDto<TreeAntdDto>> GetTreesAsync()
        {
			return await IdentityRoleAppService.GetTreesAsync();
        }
    }
}
