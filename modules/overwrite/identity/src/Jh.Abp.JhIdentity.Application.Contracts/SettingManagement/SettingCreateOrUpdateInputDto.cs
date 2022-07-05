using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.SettingManagement
{
    /// <summary>
    /// 使用前需要先在Provider中进行定义
    /// </summary>
    public class SettingCreateOrUpdateInputDto: SettingInputDto
    {
        public string Value { get; set; }
        /// <summary>
        /// 强制设置
        /// </summary>
        public bool ForceToSet { get; set; } = false;
    }
}
