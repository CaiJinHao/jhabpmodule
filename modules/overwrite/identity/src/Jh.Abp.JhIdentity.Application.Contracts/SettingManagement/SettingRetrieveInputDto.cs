using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.SettingManagement
{
    public class SettingRetrieveInputDto: SettingInputDto
    {
        public bool Fallback { get; set; } = false; 
    }
}
