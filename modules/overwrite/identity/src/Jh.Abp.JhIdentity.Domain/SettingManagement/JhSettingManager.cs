using JetBrains.Annotations;
using Microsoft.Extensions.Localization;
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
        public IAbpLazyServiceProvider LazyServiceProvider { get; set; }
        protected IStringLocalizerFactory StringLocalizerFactory => LazyServiceProvider.LazyGetRequiredService<IStringLocalizerFactory>();

        public JhSettingManager(IOptions<SettingManagementOptions> options, IServiceProvider serviceProvider, ISettingDefinitionManager settingDefinitionManager, ISettingEncryptionService settingEncryptionService) : base(options, serviceProvider, settingDefinitionManager, settingEncryptionService)
        {
        }

        public virtual async Task<List<SettingDefinitionDto>> GetEntitysAsync([CanBeNull]string providerName, string providerKey)
        {
            var settingDefinitions = SettingDefinitionManager.GetAll();
            var providers = Enumerable.Reverse(Providers);
            if (!string.IsNullOrEmpty(providerName))
            {
                providers = providers.Where(c => c.Name == providerName);
            }

            var providerList = providers.Reverse().ToList();

            var settingValues = new Dictionary<string, SettingDefinitionDto>();

            foreach (var setting in settingDefinitions)
            {
                string value = null;
                string valueProviderName = null;
                if (setting.IsInherited)
                {
                    var i = 0;
                    foreach (var provider in providerList)
                    {
                        var providerValue = await provider.GetOrNullAsync(
                            setting,
                            provider.Name == providerName ? providerKey : null
                        );
                        if (i == 0)
                        {
                            i++;
                            valueProviderName = provider.Name;
                        }
                        if (providerValue != null)
                        {
                            value = providerValue;
                            valueProviderName = provider.Name;//根据provider提供顺序加载
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

                settingValues[setting.Name] = new SettingDefinitionDto(setting.Name, value, valueProviderName, providerKey)
                {
                    Description = setting.Description.Localize(StringLocalizerFactory).ToString(),
                    DisplayName = setting.DisplayName.Localize(StringLocalizerFactory).ToString(),
                    IsEncrypted = setting.IsEncrypted,
                    IsInherited = setting.IsInherited,
                    Properties = setting.Properties
                };
            }

            return settingValues.Values.OrderByDescending(a => a.ProviderNameEnum).ToList();
        }

        public virtual async Task<SettingDefinitionDto> GetAsync(string name, string providerName, string providerKey)
        {
            Check.NotNull(providerName, nameof(providerName));
            var setting = SettingDefinitionManager.Get(name);
            var providers = Enumerable
                .Reverse(Providers);

            if (providerName != null)
            {
                providers = providers.SkipWhile(c => c.Name != providerName);
            }

            if (!setting.IsInherited)
            {
                providers = providers.TakeWhile(c => c.Name == providerName);
            }

            string value = null;
            foreach (var provider in providers)
            {
                value = await provider.GetOrNullAsync(
                    setting,
                    provider.Name == providerName ? providerKey : null
                );

                if (value != null)
                {
                    break;
                }
            }

            if (setting.IsEncrypted)
            {
                value = SettingEncryptionService.Decrypt(setting, value);
            }

            return new SettingDefinitionDto(setting.Name, value,providerName,providerKey)
            {
                Description = setting.Description.Localize(StringLocalizerFactory).ToString(),
                DisplayName = setting.DisplayName.Localize(StringLocalizerFactory).ToString(),
                IsEncrypted = setting.IsEncrypted,
                IsInherited = setting.IsInherited,
                Properties = setting.Properties
            };
        }
    }
}
