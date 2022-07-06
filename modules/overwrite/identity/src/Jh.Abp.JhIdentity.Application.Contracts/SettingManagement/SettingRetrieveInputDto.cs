using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jh.Abp.SettingManagement
{
    public class SettingRetrieveInputDto
    {
        /// <summary>
        /// 数据类型
        /// </summary>
        public string ProviderName { get; set; }
        /// <summary>
        /// 当ProviderName 为U和T的时候必填
        /// </summary>
        public string ProviderKey { get; set; }
        public string Name { get; set; }
    }
}
