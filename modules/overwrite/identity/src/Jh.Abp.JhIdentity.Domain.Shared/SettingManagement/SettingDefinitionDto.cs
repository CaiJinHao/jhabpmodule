using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Jh.Abp.SettingManagement
{
    public class SettingDefinitionDto 
    {
        public string Name { get; private set; }
        public string DisplayName { get; set; }
        public string Description { get;  set; }
        public string DefaultValue { get; private set; }
        public bool IsVisibleToClients { get; set; }
        public bool IsInherited { get; set; }
        public Dictionary<string, object> Properties { get; set; }
        public bool IsEncrypted { get; set; }

        public SettingDefinitionDto(string name,string value)
        {
            Name = name;
            DefaultValue = value;
        }
    }
}
