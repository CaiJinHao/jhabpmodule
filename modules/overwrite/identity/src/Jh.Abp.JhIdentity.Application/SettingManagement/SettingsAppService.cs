using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.Features;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace Jh.Abp.SettingManagement
{
    public class SettingsAppService: SettingManagementAppServiceBase, ISettingsAppService, ITransientDependency
    {
        protected ISettingManager SettingManager { get; }

        public SettingsAppService(ISettingManager settingManager)
        {
            SettingManager = settingManager;
        }

        protected virtual async Task CheckFeatureAsync()
        {
            await FeatureChecker.CheckEnabledAsync(SettingManagementFeatures.Enable);
            //if (CurrentTenant.IsAvailable)
            //{
            //    await FeatureChecker.CheckEnabledAsync(SettingManagementFeatures.AllowTenantsToChangeEmailSettings);
            //}
        }

        public virtual async Task<string> GetAsync(SettingRetrieveInputDto input)
        {
            await CheckFeatureAsync();
            return await SettingManager.GetOrNullAsync(input.Name, input.ProviderName, input.ProviderKey, input.Fallback);
        }

        public virtual async Task SetAsync(SettingCreateOrUpdateInputDto input)
        {
            await CheckFeatureAsync();
            //有当前租户的时候设置为租户，没有租户的时候设置为全局，尽量不要使用admin操作
            switch (input.ProviderName)
            {
                case DefaultValueSettingValueProvider.ProviderName:
                case ConfigurationSettingValueProvider.ProviderName:
                    {
                        //不支持设置
                        throw new UserFriendlyException("不支持的配置");
                    }
                default:
                    break;
            }
            //ProviderName 必须是定义的继承自SettingManagementProvider,ISettingManagementProvider的
            //C:ConfigurationSettingManagementProvider
            //D:DefaultValueSettingManagementProvider
            //G:GlobalSettingManagementProvider
            //T:TenantSettingManagementProvider
            //U:UserSettingManagementProvider
            await SettingManager.SetAsync(input.Name, input.Value, input.ProviderName, input.ProviderKey, input.ForceToSet);
        }
    }
}
