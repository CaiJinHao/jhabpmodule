using Jh.Abp.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Jh.Abp.Document.Excel
{
    /*
     https://ruilisi.github.io/fortune-sheet-docs/zh/guide/cell.html#%E5%9F%BA%E6%9C%AC%E5%8D%95%E5%85%83%E6%A0%BC
     https://ruilisi.github.io/fortune-sheet-docs/zh/guide/sheet.html#%E5%88%9D%E5%A7%8B%E5%8C%96%E9%85%8D%E7%BD%AE

     r:行 c:列 v:单元格值 ht:水平对齐 vt:垂直对其 mc:合并单元格 cs:合并得列数 rs:合并得行数   ct单元格格式 f:函数

     dynamic 类型不能套入 JObject,JObject可以套入dynamic
     */
   
    public class FortuneSheetService
    {
        /// <summary>
        /// 数字类型验证
        /// </summary>
        protected static Regex numberReg = new Regex(@"(^[\-0-9][0-9]*(.[0-9]+)?)$");

        /// <summary>
        /// 转为二维码数组
        /// </summary>
        /// <returns></returns>
        public static object[,] ConvertToDoubleArray(int totalRow, int totalCol, List<CellDto> cells)
        {
            var result = new object[totalRow, totalCol];

            foreach (var item in cells)
            {
                result[item.r, item.c] = item.v;
            }

            return result;
        }

        /// <summary>
        /// 获取公式连及cell
        /// </summary>
        /// <returns></returns>
        public static (CellDto, dynamic) GetCalcChain(string sheetId, int r, int c, object value, string f, string color = "w")
        {
            var cellValue = GetCellValue(value, f);
            var cell = new CellDto(r, c, cellValue);
            var calcChain = new { r, c, id = sheetId, color,  func = new dynamic[] { true, value, f } };
            return (cell, calcChain);
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <returns></returns>
        public static JObject GetCellValue(List<JObject> mergeCells, JObject mergeConfig, object cellValue, JObject mc, string f = null, int? bl = null, int? fs = null)
        {
            return GetCellValue(cellValue, f, bl, fs, mc, mergeCells, mergeConfig);
        }

        public static JObject GetCellValue(object cellValue, string f = null, int? bl = null, int? fs = null)
        {
            return GetCellValue(cellValue, f, bl, fs, null, null, null);
        }

        /// <summary>
        /// 获取单元格值得设置
        /// </summary>
        /// <returns></returns>
        protected static JObject GetCellValue(object cellValue, string f, int? bl, int? fs, JObject mc, List<JObject> mergeCells = null, JObject mergeConfig = null)
        {
            if (cellValue == null)
            {
                return null;
            }

            var value = cellValue.ToString();
            var result = new JObject();
            result["v"] = value;
            result["m"] = value;
            result["vt"] = "0";
            result["ht"] = "0";


            //单元格格式
            var ct = new JObject();
            ct["fa"] = "General";
            if (numberReg.IsMatch(value))
            {
                ct["t"] = "n";
            }
            else
            {
                ct["t"] = "g";
            }
            result["ct"] = ct;


            //merge
            if (mc != null)
            {
                mergeCells.Add(mc);
                mergeConfig[$"{mc["r"].Value<int>()}_{mc["c"].Value<int>()}"] = mc;
                result["mc"] = mc;
            }

            //函数
            if (f != null)
            {
                result["f"] = f;
            }

            //加粗
            if (bl != null)
            {
                result["bl"] = bl;
            }

            //字体大小
            if (fs != null)
            {
                result["fs"] = fs;
            }

            return result;
        }

        /// <summary>
        /// 添加被合并的单元格
        /// </summary>
        public static void AddMergCell(object[,] data, List<JObject> mcs)
        {
            foreach (var mc in mcs)
            {
                //只跨行不跨列
                var _r = mc["r"].Value<int>();
                var _c = mc["c"].Value<int>();
                var _rs = mc["rs"].Value<int>();
                var _cs = mc["cs"].Value<int>();
                for (int r = _r; r < (_r + _rs); r++)
                {
                    if (r != _r)
                    {
                        data[r, _c] = new { mc = new { r = _r, c = _c } };
                    }
                }

                //只跨列不跨行
                for (int c = _c; c < (_c + _cs); c++)
                {
                    if (c != _c)
                    {
                        data[_r, c] = new { mc = new { r = _r, c = _c } };
                    }
                }

                //上面两个相加就够用跨行又跨列了(待验证)

                //跨行又跨列(待验证)
                /* for (int r = mc.r; r < mc.rs; r++)
                 {
                     for (int c = mc.c; c < mc.cs; c++)
                     {
                         if (r != mc.r && c != mc.c)//已经有的单元格不再添加
                         {
                             //这里需要直接操作二位数组
                             data[r, c] = new { mc = new { mc.r, mc.c } };//这是被合并的单元格
                         }
                     }
                 }*/
            }
        }
    }
}
