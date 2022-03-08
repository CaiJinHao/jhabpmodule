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

namespace Jh.Abp.JhPermission
{
    [RemoteService(Name = JhIdentityRemoteServiceConsts.RemoteServiceName)]
    [Area(JhIdentityRemoteServiceConsts.ModuleName)]
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
    public class JhPermissionsController : PermissionsController
    {
        public JhPermissionsController(IPermissionAppService permissionAppService) : base(permissionAppService)
        {
        }

        public IJhPermissionAppService jhPermissionAppService { get; set; }

        [DisableAuditing]
        [HttpPost("PermissionGranted")]
        public virtual async Task<IEnumerable<PermissionGrantedDto>> GetPermissionGrantedByNameAsync([FromBody] PermissionGrantedRetrieveInputDto input)
        {
            return await jhPermissionAppService.GetPermissionGrantedByNameAsync(input);
        }

        [HttpGet("InterfaceTreesAll")]
        public virtual async Task<dynamic> GetInterfaceTreesAsync([FromQuery] PermissionGrantedRetrieveInputDto input)
        {
            var items = await jhPermissionAppService.GetPermissionTreesAsync(input.ProviderName, input.ProviderKey);
            return new { items };
        }

        [HttpPost("Interface")]
        public virtual async Task UpdateInterfaceAsync(PermissionGrantedCreateInputDto inputDto)
        {
            await jhPermissionAppService.UpdateAsync(inputDto.ProviderName, inputDto.ProviderKey, inputDto.PermissionNames);
        }
    }
}
