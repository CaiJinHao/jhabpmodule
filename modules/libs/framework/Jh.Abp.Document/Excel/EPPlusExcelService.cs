﻿using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Jh.Abp.Document.Excel.Models;

namespace Jh.Abp.Document.Excel
{
    public class EPPlusExcelService: IExcelService
    {
        public EPPlusExcelService() 
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workSheet"></param>
        /// <param name="row">从0开始</param>
        /// <param name="col">从0开始</param>
        /// <param name="dataCell"></param>
        protected virtual void SetExcelRange(ExcelWorksheet workSheet, int row, int col, JObject dataCell) 
        {
            ExcelRange cell = null;
            var isMerge = false;
            if (dataCell["mc"] != null)
            {
                var mc = dataCell["mc"];
                var _r = mc["r"].Value<int>();
                var _c = mc["c"].Value<int>();
                var _rs = mc["rs"];
                var _cs = mc["cs"];
                if (_rs != null && _cs != null)
                {
                    cell = workSheet.Cells[_r + 1, _c + 1, _r + _rs.Value<int>(), _c + _cs.Value<int>()];
                    isMerge = true;
                }
                else
                {
                    //被合并的单元格不处理
                    return;
                }
            }
            else
            {
                cell = workSheet.Cells[row + 1, col + 1];
            }

            //顺序不能更换，先赋值，后合并
            cell.Value = dataCell["v"].Value<string>();
            if (isMerge)
            {
                cell.Merge = true;
            }

            //函数公式
            var f = dataCell["f"];
            if (f != null)
            {
                cell.Formula = f.Value<string>();
            }

            //加粗
            var bl = dataCell["bl"];
            if (bl != null)
            {
                cell.Style.Font.Bold = true;
            }

            //字体大小
            var fs = dataCell["fs"];
            if (fs != null)
            {
                cell.Style.Font.Size = fs.Value<int>();
            }
        }

        /// <summary>
        /// 全局设置
        /// </summary>
        protected virtual void SetWorksheets(ExcelWorksheet workSheet,SheetDto sheetData)
        {
            workSheet.Cells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            workSheet.Cells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            workSheet.Cells.Style.WrapText = true;//自动换行
            workSheet.Cells.AutoFitColumns(20, 100);

            var rowlen = sheetData.config["rowlen"];
            if (rowlen != null)
            {
                foreach (JProperty item in rowlen)
                {
                    var rowIndex = Convert.ToInt32(item.Name);
                    var excelRow = workSheet.Row(rowIndex == 0 ? 1 : rowIndex);
                    excelRow.Height = item.Value.Value<int>();
                }
            }
        }

        public virtual async Task<byte[]> CreateSheetsByDoubleArrayAsync(List<Jh.Abp.Document.Excel.Models.SheetDto> sheets, Action<ExcelWorksheet> actionSheet = null)
        {
            using (var package = new ExcelPackage())
            {
                foreach (var sheet in sheets)
                {
                    var sheetDataCells = sheet.data;
                    var workSheet = package.Workbook.Worksheets.Add(sheet.name);

                    for (int row = 0; row < sheetDataCells.GetLength(0); row++)
                    {
                        for (int col = 0; col < sheetDataCells.GetLength(1); col++)
                        {
                            var dataCell = sheetDataCells[row, col] as JObject;
                            if (dataCell != null)
                            {
                                SetExcelRange(workSheet, row, col, dataCell);
                            }
                            //没有值的不处理
                        }
                    }

                    SetWorksheets(workSheet, sheet);
                    actionSheet?.Invoke(workSheet);
                }
                return await package.GetAsByteArrayAsync();
            }
        }

        public virtual async Task<byte[]> CreateSheetsAsync(List<Jh.Abp.Document.Excel.Models.SheetDto> sheets, Action<ExcelWorksheet> actionSheet = null)
        {
            using (var package = new ExcelPackage())
            {
                foreach (var sheet in sheets)
                {
                    var sheetDataCells = sheet.celldata;
                    var workSheet = package.Workbook.Worksheets.Add(sheet.name);

                    foreach (var cell in sheetDataCells)
                    {
                        var dataCell = cell.v as JObject;
                        if (dataCell != null)
                        {
                            SetExcelRange(workSheet, cell.r, cell.c, dataCell);
                        }
                    }

                    SetWorksheets(workSheet,sheet);
                    actionSheet?.Invoke(workSheet);
                }
                return await package.GetAsByteArrayAsync();
            }
        }
    }
}
