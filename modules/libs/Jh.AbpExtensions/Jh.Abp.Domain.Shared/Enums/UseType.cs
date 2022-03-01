using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Jh.Abp.Domain.Shared
{
    /// <summary>
    /// 可用类型(是or否)
    /// </summary>
    public enum UseType
    {
        //[Description("无")]
        //None = 0,
        [Description("是")]
        Yes = 1,
        [Description("否")]
        No = 2,
    }

    /// <summary>
    /// 如果加上无，前端会显示出来
    /// </summary>
    public enum DeleteType
    {
        //[Description("无")]
        //None = 0,
        [Description("是")]
        Yes = 1,
        [Description("否")]
        No = 2,
    }
}
