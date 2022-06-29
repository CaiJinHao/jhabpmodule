using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.Document.Excel.Models
{
    public class SheetDto
    {
        public string id { get;  set; }
        public string name { get;  set; }
        /// <summary>
        /// 激活状态 只能有一个为激活，1：激活，0：未激活
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 工作表的下标
        /// </summary>
        public string order { get; set; } = "0";
        public int zoomRatio { get; set; } = 1;
        public int row { get;  set; }
        public int column { get;  set; }
        public  int defaultRowHeight { get;  set; }
        public int defaultColWidth { get;  set; }

        public List<CellDto> celldata { get;  set; }

        /// <summary>
        /// 二维数组数据
        /// </summary>
        public object[,] data { get;  set; }
        public JObject config { get; set; }
        /// <summary>
        /// 公式
        /// </summary>
        public List<object> calcChain { get; set; }

        public SheetDto() { }

        /// <summary>
        /// 二维表格
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_name"></param>
        /// <param name="_row"></param>
        /// <param name="_col"></param>
        /// <param name="_rowHeight"></param>
        /// <param name="_colWidth"></param>
        /// <param name="_data"></param>
        public SheetDto(string _id,string _name,int _row, int _col, int _rowHeight, int _colWidth, object[,] _data)
        {
            data = _data;
            id = _id;
            name = _name;
            row = _row;
            column = _col;
            defaultRowHeight = _rowHeight;
            defaultColWidth = _colWidth;
        }

        /// <summary>
        /// sheet对象
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_name"></param>
        /// <param name="_row"></param>
        /// <param name="_col"></param>
        /// <param name="_rowHeight"></param>
        /// <param name="_colWidth"></param>
        /// <param name="_data"></param>
        public SheetDto(string _id, string _name, int _row, int _col, int _rowHeight, int _colWidth,List<CellDto> _data)
        {
            celldata = _data;
            id = _id;
            name = _name;
            row = _row;
            column = _col;
            defaultRowHeight = _rowHeight;
            defaultColWidth = _colWidth;
        }
    }
}
