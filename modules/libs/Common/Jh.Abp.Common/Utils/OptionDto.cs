using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.Common.Utils
{
    public class OptionDto<TValue>
    {
        /// <summary>
        /// layui使用
        /// </summary>
        public string Text { get { return Label; } }
        /// <summary>
        /// antd 使用
        /// </summary>
        public string Label { get; set; }
        public TValue Value { get; set; }
        public dynamic Data { get; set; }
    }
}
