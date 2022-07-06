using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Settings;

namespace Jh.Abp.SettingManagement
{
    public interface ISettingsAppService
    {
        Task<SettingDefinitionDto> GetAsync(SettingRetrieveInputDto input);
        Task SetAsync(SettingCreateOrUpdateInputDto input);
        Task<ListResultDto<SettingDefinitionDto>> GetAllAsync(SettingRetrieveInputDto input);
    }
}
