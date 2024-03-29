﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Jh.Abp.Domain.Shared
{
    [Obsolete("Please Use YesOrNo")]
    public enum UseType
    {
        None = 0,
        [Description("是")]
        Yes,
        [Description("否")]
        No,
    }

    [Obsolete("Please Use YesOrNo")]
    public enum DeleteType
    {
        None = 0,
        [Description("是")]
        Yes,
        [Description("否")]
        No,
    }

    /*
     枚举不传值就是全部
    没有0，要么1要么2，要么空
     */

    /// <summary>
    /// bool 值也可以使用 1:true,2:false
    /// 针对后台枚举使用
    /// </summary>
    public enum YesOrNo
    {
        [Description("是")]
        Yes=1,
        [Description("否")]
        No,
    }

    /// <summary>
    /// 针对前端Form表单查询筛选使用
    /// </summary>
    public enum YesOrNoOption
    {
        [Description("否")]
        No =1,
        [Description("是")]
        Yes,
    }
}
