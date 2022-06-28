using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.Document.Excel
{
    public class CellDto
    {
        /// <summary>
        /// row
        /// </summary>
        public int r { get; set; }
        /// <summary>
        /// col
        /// </summary>
        public int c { get; set; }
        public CellValueDto v { get; set; }
    }
}
