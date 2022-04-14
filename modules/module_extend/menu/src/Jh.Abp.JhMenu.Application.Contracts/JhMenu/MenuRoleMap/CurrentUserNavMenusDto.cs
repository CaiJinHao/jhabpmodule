using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.JhMenu
{
    /// <summary>
    /// 当前登录用户导航菜单 适用于 antd pro
    /// </summary>
    public class CurrentUserNavMenusDto
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<CurrentUserNavMenusDto> Routes { get; set; }

        public string Code { get; set; }
        public string ParentCode { get; set; }
        public int Sort { get; set; }
    }
}
