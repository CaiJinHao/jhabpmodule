using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.SourceGenerator.Common
{
    public abstract class CodeBuilderBase
    {
        public string FilePath { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        public string Suffix { get; set; }
    }
}
