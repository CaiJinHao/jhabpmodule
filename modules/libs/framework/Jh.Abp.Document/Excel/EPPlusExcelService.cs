using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Jh.Abp.Document.Excel
{
    public class EPPlusExcelService: IExcelService
    {
        public EPPlusExcelService() : base()
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
                var mc = dataCell["mc"] as JObject;
                var _r = mc["r"].Value<int>();
                var _c = mc["c"].Value<int>();
                cell = workSheet.Cells[_r + 1, _c + 1, _r + mc["rs"].Value<int>(), _c + mc["cs"].Value<int>()];
                isMerge = true;
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
            if (dataCell["f"] != null)
            {
                cell.Formula = dataCell["f"].Value<string>();
            }

            //加粗
            if (dataCell["bl"] != null)
            {
                cell.Style.Font.Bold = true;
            }

            //字体大小
            if (dataCell["fs"] != null)
            {
                cell.Style.Font.Size = dataCell["fs"].Value<int>();
            }
        }

        /// <summary>
        /// 全局设置
        /// </summary>
        /// <param name="workSheet"></param>
        protected virtual void SetWorksheets(ExcelWorksheet workSheet)
        {
            workSheet.Cells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            workSheet.Cells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            workSheet.Cells.Style.WrapText = true;//自动换行
            workSheet.Cells.AutoFitColumns(20, 100);
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
                        }
                    }

                    SetWorksheets(workSheet);
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

                    SetWorksheets(workSheet);
                    actionSheet?.Invoke(workSheet);
                }
                return await package.GetAsByteArrayAsync();
            }
        }
    }
}
