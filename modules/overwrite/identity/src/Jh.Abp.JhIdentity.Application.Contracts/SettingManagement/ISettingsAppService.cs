using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Settings;

namespace Jh.Abp.SettingManagement
{
    public interface ISettingsAppService
    {
        Task<string> GetAsync(SettingRetrieveInputDto input);
        Task SetAsync(SettingCreateOrUpdateInputDto input);
        Task<List<SettingValue>> GetAllAsync(SettingRetrieveInputDto input);
    }
}
