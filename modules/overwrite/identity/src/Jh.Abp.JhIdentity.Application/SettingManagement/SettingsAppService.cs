using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.Features;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;
using System.Linq;

namespace Jh.Abp.SettingManagement
{
    public class SettingsAppService: SettingManagementAppServiceBase, ISettingsAppService, ITransientDependency
    {
        protected IJhSettingManager SettingManager { get; }

        public SettingsAppService(IJhSettingManager settingManager)
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

        public virtual async Task<SettingDefinitionDto> GetAsync(SettingRetrieveInputDto input)
        {
            await CheckFeatureAsync();
            return await SettingManager.GetAsync(input.Name, input.ProviderName, input.ProviderKey);
        }

        public virtual async Task<ListResultDto<SettingDefinitionDto>> GetAllAsync(SettingRetrieveInputDto input)
        {
            var datas = await SettingManager.GetEntitysAsync(input.ProviderName, input.ProviderKey);
            return new ListResultDto<SettingDefinitionDto>(datas);
        }

        public virtual async Task SetAsync(SettingCreateOrUpdateInputDto input)
        {
            await CheckFeatureAsync();
            switch (input.ProviderName)
            {
                case ProviderNameEnum.D:
                case ProviderNameEnum.C:
                    {
                 /*   DefaultValueSettingManagementProvider: 从设置定义的默认值中获取值,由于默认值是硬编码在设置定义上的,所以无法更改默认值.
ConfigurationSettingManagementProvider:从 IConfiguration 服务中获取值.由于无法在运行时更改配置值,所以无法更改配置值.*/
                        throw new UserFriendlyException("不支持的配置");
                    }
                case ProviderNameEnum.U:
                case ProviderNameEnum.T:
                    { 
                        Check.NotNull(input.ProviderKey, nameof(input.ProviderKey), "ProviderKey Is Required");
                    }
                    break;
                case ProviderNameEnum.G:
                default:
                    break;
            }
            //ProviderName 必须是定义的继承自SettingManagementProvider,ISettingManagementProvider的
            //C:ConfigurationSettingManagementProvider
            //D:DefaultValueSettingManagementProvider
            //G:GlobalSettingManagementProvider ProviderKey=NULL 唯一索引： ProviderName,Name 
            //T和U设置的Name和Value不能和G的Value一样，否则会删掉使用G,U和T可以重复
            //T:TenantSettingManagementProvider  ProviderKey=TenantId   唯一索引： ProviderName,Name,ProviderKey
            //U:UserSettingManagementProvider ProviderKey=UserId   唯一索引： ProviderName,Name,ProviderKey
            await SettingManager.SetAsync(input.Name, input.Value, input.ProviderName.ToString(), input.ProviderKey, input.ForceToSet);
        }
    }
}
