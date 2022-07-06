using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace Jh.Abp.SettingManagement
{
    public class JhSettingManager : SettingManager, IJhSettingManager, ISingletonDependency
    {
        public JhSettingManager(IOptions<SettingManagementOptions> options, IServiceProvider serviceProvider, ISettingDefinitionManager settingDefinitionManager, ISettingEncryptionService settingEncryptionService) : base(options, serviceProvider, settingDefinitionManager, settingEncryptionService)
        {
        }

        public virtual async Task<List<SettingDefinitionDto>> GetEntitysAsync(string providerName, string providerKey, bool fallback = true)
        {
            Check.NotNull(providerName, nameof(providerName));

            var settingDefinitions = SettingDefinitionManager.GetAll();
            var providers = Enumerable.Reverse(Providers)
                .SkipWhile(c => c.Name != providerName);

            if (!fallback)
            {
                providers = providers.TakeWhile(c => c.Name == providerName);
            }

            var providerList = providers.Reverse().ToList();

            if (!providerList.Any())
            {
                return new List<SettingDefinitionDto>();
            }

            var settingValues = new Dictionary<string, SettingDefinitionDto>();

            foreach (var setting in settingDefinitions)
            {
                string value = null;

                if (setting.IsInherited)
                {
                    foreach (var provider in providerList)
                    {
                        var providerValue = await provider.GetOrNullAsync(
                            setting,
                            provider.Name == providerName ? providerKey : null
                        );
                        if (providerValue != null)
                        {
                            value = providerValue;
                        }
                    }
                }
                else
                {
                    value = await providerList[0].GetOrNullAsync(
                        setting,
                        providerKey
                    );
                }

                if (setting.IsEncrypted)
                {
                    value = SettingEncryptionService.Decrypt(setting, value);
                }

                if (value != null)
                {
                    settingValues[setting.Name] = new SettingDefinitionDto(setting.Name, value)
                    {
                        Description = setting.Description.ToString(),
                        DisplayName = setting.DisplayName.ToString(),
                        IsEncrypted = setting.IsEncrypted,
                        IsInherited = setting.IsInherited,
                        IsVisibleToClients = setting.IsVisibleToClients,
                        Properties = setting.Properties
                    };
                }
            }

            return settingValues.Values.ToList();
        }
    }
}
