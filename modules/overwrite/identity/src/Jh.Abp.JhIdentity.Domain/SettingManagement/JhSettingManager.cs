using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public override Task<List<SettingValue>> GetAllAsync(string providerName, string providerKey, bool fallback = true)
        {
            //TODO:重写，需要显示汉字名称
            return base.GetAllAsync(providerName, providerKey, fallback);
        }
    }
}
