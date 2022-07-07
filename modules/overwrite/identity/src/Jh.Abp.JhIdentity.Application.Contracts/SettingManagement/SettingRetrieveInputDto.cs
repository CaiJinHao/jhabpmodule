using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jh.Abp.SettingManagement
{
    public class SettingRetrieveInputDto
    {
        /// <summary>
        /// 数据类型,可以接收字符串和int
        /// </summary>
        public ProviderNameEnum? ProviderName { get; set; }
        /// <summary>
        /// 当ProviderName 为U和T的时候必填
        /// </summary>
        public string ProviderKey { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
