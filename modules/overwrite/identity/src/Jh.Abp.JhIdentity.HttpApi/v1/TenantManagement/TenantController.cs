using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.PermissionManagement;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Jh.Abp.JhIdentity;
using Volo.Abp.Application.Dtos;
using Jh.Abp.Common;
using Microsoft.AspNetCore.Authorization;
using Jh.Abp.SettingManagement;
using Jh.Abp.SettingManagement.Permissions;
using Volo.Abp.Settings;
using Jh.Abp.TenantManagement;
using Volo.Abp.Data;
using Volo.Abp.TenantManagement;
using TenantDto = Jh.Abp.TenantManagement.TenantDto;

namespace Jh.Abp.JhIdentity.v1.TenantManagement
{
    [Authorize]
    [RemoteService(Name = JhIdentityRemoteServiceConsts.RemoteServiceName)]
    [Area(JhIdentityRemoteServiceConsts.ModuleName)]
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
    public class TenantController : JhIdentityController, IJhTenantAppService
    {
		public IDataFilter<ISoftDelete> DataFilterDelete { get; set; }
		protected IJhTenantAppService jhTenantAppService => LazyServiceProvider.LazyGetRequiredService<IJhTenantAppService>();

		[Authorize(TenantManagementPermissions.Tenants.Create)]
		[HttpPost]
		public Task<TenantDto> CreateAsync(TenantCreateDto input)
		{
			throw new NotImplementedException();
		}

		[Authorize(TenantManagementPermissions.Tenants.Delete)]
		[Route("{id}")]
		[HttpDelete]
		public virtual Task DeleteAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		[Authorize(TenantManagementPermissions.Tenants.Delete)]
		[Route("keys")]
		[HttpDelete]
		public virtual Task DeleteAsync([FromBody] System.Guid[] keys)
		{
			throw new NotImplementedException();
		}

		[Authorize(TenantManagementPermissions.Tenants.Update)]
		[Route("{id}")]
		[HttpPut]
		public virtual Task<TenantDto> UpdateAsync(System.Guid id, TenantUpdateDto input)
		{
			throw new NotImplementedException();
		}


		[Authorize(TenantManagementPermissions.Tenants.Default)]
		[HttpGet]
		public virtual async Task<PagedResultDto<TenantDto>> GetListAsync([FromQuery] TenantRetrieveInputDto input)
		{
			using (DataFilterDelete.Disable())
			{
				return await jhTenantAppService.GetListAsync(input);
			}
		}

		[Authorize(TenantManagementPermissions.Tenants.Default)]
		[Route("{id}")]
		[HttpGet]
		public virtual async Task<TenantDto> GetAsync(System.Guid id)
		{
			return await jhTenantAppService.GetAsync(id);
		}


		[Authorize(TenantManagementPermissions.Tenants.Default)]
		[Route("all")]
		[HttpGet]
		public virtual async Task<ListResultDto<TenantDto>> GetEntitysAsync([FromQuery] TenantRetrieveInputDto inputDto)
		{
			return await jhTenantAppService.GetEntitysAsync(inputDto);
		}


		[Authorize(TenantManagementPermissions.Tenants.Update)]
		[Route("Patch/{id}")]
		[HttpPut]
		public virtual Task UpdatePortionAsync(System.Guid id, TenantUpdateDto inputDto)
		{
			throw new NotImplementedException();
		}
	}
}
