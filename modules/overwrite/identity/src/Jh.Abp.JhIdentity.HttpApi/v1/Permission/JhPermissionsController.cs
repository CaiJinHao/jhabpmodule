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

namespace Jh.Abp.JhPermission
{
    [Authorize]
    [DisableAuditing]
    [RemoteService(Name = JhIdentityRemoteServiceConsts.RemoteServiceName)]
    [Area(JhIdentityRemoteServiceConsts.ModuleName)]
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
    public class JhPermissionsController : PermissionsController, IJhPermissionAppService
    {
        public JhPermissionsController(IPermissionAppService permissionAppService) : base(permissionAppService)
        {
        }

        public IJhPermissionAppService jhPermissionAppService { get; set; }

        [Route("GrantedByRole")]
        [HttpGet]
        public async Task<ListResultDto<string>> GetPermissionGrantedByRoleAsync(PermissionGrantedRetrieveInputDto input)
        {
            return await jhPermissionAppService.GetPermissionGrantedByRoleAsync(input);
        }

        [Route("GrantedByRole")]
        [HttpPut]
        public virtual async Task UpdateAsync(PermissionGrantedCreateInputDto inputDto)
        {
            await jhPermissionAppService.UpdateAsync(inputDto);
        }

        [Route("Tree")]
        [HttpGet]
        public async Task<ListResultDto<TreeAntdDto>> GetTreesAsync(PermissionTreesRetrieveInputDto inputDto)
        {
            return await jhPermissionAppService.GetTreesAsync(inputDto);
        }
    }
}
