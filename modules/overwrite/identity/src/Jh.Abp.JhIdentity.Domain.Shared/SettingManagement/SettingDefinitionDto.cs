using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Jh.Abp.SettingManagement
{
    public class SettingDefinitionDto 
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string DisplayName { get; set; }
        public string Description { get;  set; }
        public string DefaultValue { get; private set; }
        public bool IsInherited { get; set; }
        public Dictionary<string, object> Properties { get; set; }
        public bool IsEncrypted { get; set; }

        public string ProviderName { get;private set; }
        public string ProviderKey { get;private set; }

        public SettingDefinitionDto(string name,string value,string providerName,string providerKey)
        {
            Name = name;
            DefaultValue = value;
            ProviderName = providerName;
            ProviderKey = providerKey;
            Id = $"{providerName}_{providerKey}_{name}";
        }
    }
}
