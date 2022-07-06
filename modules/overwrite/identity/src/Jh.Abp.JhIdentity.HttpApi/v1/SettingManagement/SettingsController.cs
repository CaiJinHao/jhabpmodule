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

namespace Jh.Abp.JhIdentity.v1.SettingManagement
{
    [Authorize]
    [RemoteService(Name = JhIdentityRemoteServiceConsts.RemoteServiceName)]
    [Area(JhIdentityRemoteServiceConsts.ModuleName)]
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
    public class SettingsController : JhIdentityController, ISettingsAppService
    {
        public ISettingsAppService settingsAppService { get; set; }

        [Authorize(JhSettingManagementPermissions.Settings.Default)]
        [Route("all")]
        [HttpGet]
        public async Task<ListResultDto<SettingDefinitionDto>> GetAllAsync(SettingRetrieveInputDto input)
        {
            return await settingsAppService.GetAllAsync(input);
        }

        [Authorize(JhSettingManagementPermissions.Settings.Default)]
        [HttpGet]
        public async Task<SettingDefinitionDto> GetAsync(SettingRetrieveInputDto input)
        {
            return await settingsAppService.GetAsync(input);
        }

        [Authorize(JhSettingManagementPermissions.Settings.Update)]
        [HttpPut]
        public async Task SetAsync(SettingCreateOrUpdateInputDto input)
        {
            await settingsAppService.SetAsync(input);
        }
    }
}
