using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.Document.Excel
{
    public class CellValueDto
    {
        public string v { get; set; }
        public string m { get; set; }
        /// <summary>
        /// 是否垂直居中 0:居中
        /// </summary>
        public string vt { get; set; }
        /// <summary>
        /// 是否水平居中 0:居中
        /// </summary>
        public string ht { get; set; }
        /// <summary>
        /// 函数
        /// </summary>
        public string f { get; set; }
        /// <summary>
        /// 加粗
        /// </summary>
        public string bl { get; set; }
        /// <summary>
        /// 字体大小
        /// </summary>
        public string fs { get; set; }

        /// <summary>
        /// 合并单元格
        /// </summary>
        public object mc { get; set; }
        /// <summary>
        /// 单元格格式
        /// </summary>
        public object ct { get; set; }
    }
}
