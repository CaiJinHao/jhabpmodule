using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Jh.Abp.Workflow
{
    public enum BacklogResultType
    {
        /// <summary>
        /// 未处理
        /// </summary>
        [Description("未处理")]
        Untreated,
        /// <summary>
        /// 同意
        /// </summary>
        [Description("同意")]
        Agree,
        /// <summary>
        /// 拒绝
        /// </summary>
        [Description("拒绝")]
        Reject,
        /// <summary>
        /// 流转
        /// </summary>
        [Description("流转")]
        Circulation
    }
}
