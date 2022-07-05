using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Jh.Abp.SettingManagement
{
    public enum ProviderNameEnum
    {
        /// <summary>
        /// DefaultValueSettingManagementProvider
        /// </summary>
        [Description("DefaultSetting")]
        D,
        /// <summary>
        /// ConfigurationSettingManagementProvider
        /// </summary>
        [Description("ConfigurationSetting")]
        C,
        /// <summary>
        /// GlobalSettingManagementProvider
        /// </summary>
        [Description("GlobalSetting")]
        G,
        /// <summary>
        /// UserSettingManagementProvider
        /// </summary>
        [Description("UserSetting")]
        U,
        /// <summary>
        /// TenantSettingManagementProvider
        /// </summary>
        [Description("TenantSetting")]
        T
    }
}
