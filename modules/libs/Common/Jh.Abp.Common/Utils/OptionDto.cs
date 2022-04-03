using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.Common.Utils
{
    public class OptionDto<TValue>
    {
        public string Text { get; set; }
        public TValue Value { get; set; }
        public dynamic Data { get; set; }
    }
}
