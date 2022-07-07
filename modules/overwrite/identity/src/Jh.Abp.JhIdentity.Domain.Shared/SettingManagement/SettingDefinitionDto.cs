using Jh.Abp.Common;
using System;
using System.Collections.Generic;

namespace Jh.Abp.SettingManagement
{
    public class SettingDefinitionDto 
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string DisplayName { get; set; }
        public string Description { get;  set; }
        public string Value { get; private set; }
        public bool IsInherited { get; set; }
        public Dictionary<string, object> Properties { get; set; }
        public bool IsEncrypted { get; set; }
        public string ProviderName { get { return ProviderNameEnum.ToDescription(); } }
        public string ProviderKey { get; private set; }
        public ProviderNameEnum ProviderNameEnum { get; private set; }

        public SettingDefinitionDto(string name,string value,string providerName,string providerKey)
        {
            Name = name;
            Value = value;
            ProviderKey = providerKey;
            Id = $"{providerName}_{providerKey}_{name}";
            ProviderNameEnum = (ProviderNameEnum)Enum.Parse(typeof(ProviderNameEnum), providerName);
        }
    }
}
