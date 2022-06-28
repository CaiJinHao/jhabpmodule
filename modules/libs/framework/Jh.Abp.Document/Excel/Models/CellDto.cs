using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.Document.Excel
{
    public class CellDto
    {
        /// <summary>
        /// row  从0开始
        /// </summary>
        public int r { get; set; }
        /// <summary>
        /// col 从0开始
        /// </summary>
        public int c { get; set; }
        public JObject v { get; set; }

        public CellDto() { }
        public CellDto(int _r, int _c)
        {
            r = _r;
            c = _c;
        }
        public CellDto(int _r,int _c,JObject _v) {
            r = _r;
            c = _c;
            v = _v;
        }
    }
}
