using System;
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

    public enum YesOrNo
    {
        None,
        [Description("是")]
        Yes,
        [Description("否")]
        No,
    }
}
