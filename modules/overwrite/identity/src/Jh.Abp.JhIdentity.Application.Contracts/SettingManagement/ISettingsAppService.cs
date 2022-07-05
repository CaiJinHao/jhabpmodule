using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jh.Abp.SettingManagement
{
    public interface ISettingsAppService
    {
        Task<string> GetAsync(SettingRetrieveInputDto input);
        Task SetAsync(SettingCreateOrUpdateInputDto input);
    }
}
