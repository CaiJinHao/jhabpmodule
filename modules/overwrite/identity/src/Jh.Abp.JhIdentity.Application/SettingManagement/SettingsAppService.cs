using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.Features;
using Volo.Abp.SettingManagement;

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
            if (CurrentTenant.IsAvailable)
            {
                await FeatureChecker.CheckEnabledAsync(SettingManagementFeatures.AllowTenantsToChangeEmailSettings);
            }
        }

        public virtual async Task<string> GetAsync(string name)
        {
            await CheckFeatureAsync();
            //var smtpHost = await SettingProvider.GetOrNullAsync(EmailSettingNames.Smtp.Host);
            //SettingProvider.GetAllAsync();
            //可以重写SettingProvider
            return await SettingProvider.GetOrNullAsync(name);
        }

        public virtual async Task UpdateByTenantAsync([NotNull] string name, [CanBeNull] string value, bool forceToSet = false)
        {
            await CheckFeatureAsync();

            await SettingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, name, value, forceToSet);
        }
    }
}
