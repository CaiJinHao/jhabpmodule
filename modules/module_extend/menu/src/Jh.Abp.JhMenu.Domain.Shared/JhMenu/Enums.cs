using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.JhMenu
{
    /// <summary>
    /// 枚举多选使用与&运算。定义值为0,1,2,4,8.....;
    /// 多选赋值7=0+1+2+4
    /// 7=MenuRegisterType.SystemSetting | MenuRegisterType.Commodity | MenuRegisterType.Article | MenuRegisterType.File
    /// </summary>
    public enum MenuRegisterType
    {
        /// <summary>
        /// 系统设置菜单
        /// </summary>
        SystemSetting = 0,
        /// <summary>
        /// 商品系统菜单
        /// </summary>
        Commodity=1,
        /// <summary>
        /// 文件系统菜单
        /// </summary>
        File=2,
        /// <summary>
        /// 文章系统菜单
        /// </summary>
        Article=4,
        /// <summary>
        /// WebApp
        /// </summary>
        WebApp=8,
    }
}
