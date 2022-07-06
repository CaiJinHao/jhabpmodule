using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.SettingManagement;

namespace Jh.Abp.SettingManagement
{
    public interface IJhSettingManager: ISettingManager
    {
        Task<List<SettingDefinitionDto>> GetEntitysAsync(string providerName, string providerKey, bool fallback = true);
        Task<SettingDefinitionDto> GetAsync(string name, string providerName, string providerKey, bool fallback = true);
    }
}
