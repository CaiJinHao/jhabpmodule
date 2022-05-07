using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.JhMenu
{
    public class JhMenuConsts
    {
        public static MenuRegisterType MenuRegisterType { get; set; } = MenuRegisterType.SystemSetting;
        /// <summary>
        /// 当前端使用AntdPro的时候需要开启
        /// </summary>
        public static bool IsAntdPro = false;
    }
}
