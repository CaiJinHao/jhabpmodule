using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jh.Abp.SettingManagement
{
    /// <summary>
    /// 使用前需要先在Provider中进行定义
    /// </summary>
    public class SettingCreateOrUpdateInputDto
    {
        /// <summary>
        /// 枚举传字符串不区分大小写
        /// </summary>
        [Required]
        public ProviderNameEnum ProviderName { get; set; }

        /// <summary>
        /// 租户ID,用户ID,等自定义,当前登录的租户、用户直接传NULL
        /// </summary>
        public string ProviderKey { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }
        /// <summary>
        /// 强制设置
        /// </summary>
        public bool ForceToSet { get; set; } = false;
    }
}
