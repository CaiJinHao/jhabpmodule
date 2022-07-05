using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.SettingManagement
{
    public class SettingInputDto
    {
        /// <summary>
        /// 数据类型
        /// </summary>
        public string ProviderName { get; set; }
        /// <summary>
        /// 租户ID,用户ID,等自定义,当前登录的租户、用户直接传NULL
        /// </summary>
        public string ProviderKey { get; set; }
        public string Name { get; set; }
    }
}
