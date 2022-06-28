using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.Document.Excel.Models
{
    public class SheetDto
    {
        public string id { get; private set; }
        public string name { get; private set; }
        /// <summary>
        /// 激活状态 只能有一个为激活，1：激活，0：未激活
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 工作表的下标
        /// </summary>
        public string order { get; set; } = "0";
        public int zoomRatio { get; set; } = 1;
        public int row { get; private set; }
        public int column { get; private set; }
        public  int defaultRowHeight { get; private set; }
        public int defaultColWidth { get; private set; }
        /// <summary>
        /// 二维数组数据
        /// </summary>
        public object[,] data { get; set; }
        ///// <summary>
        ///// 一维对象
        ///// </summary>
        //public List<dynamic> celldata { get; set; }
        public dynamic config { get; set; }
        /// <summary>
        /// 公式
        /// </summary>
        public List<dynamic> calcChain { get; set; }

        public SheetDto(string _id,string _name,int _row, int _col, int _rowHeight, int _colWidth)
        {
            id = _id;
            name = _name;
            row = _row;
            column = _col;
            defaultRowHeight = _rowHeight;
            defaultColWidth = _colWidth;
        }
    }
}
