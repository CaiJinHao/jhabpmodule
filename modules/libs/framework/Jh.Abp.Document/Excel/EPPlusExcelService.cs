using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jh.Abp.Document.Excel
{
    public class EPPlusExcelService: ExcelService
    {
        public EPPlusExcelService() : base()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public void CreateSheetAsync(Jh.Abp.Document.Excel.Models.SheetDto sheet)
        {
            
        }

        protected virtual void SetExcelRange(ExcelWorksheet workSheet, int row, int col, JObject dataCell) {
            ExcelRange cell = null;

            var setCellValue = () => cell.Value = dataCell["v"].Value<string>();

            if (dataCell["mc"] != null)
            {
                var mc = dataCell["mc"] as JObject;
                var _r = mc["r"].Value<int>();
                var _c = mc["c"].Value<int>();
                cell = workSheet.Cells[_r + 1, _c + 1, _r + mc["rs"].Value<int>(), _c + mc["cs"].Value<int>()];
                setCellValue();
                cell.Merge = true;
            }
            else
            {
                cell = workSheet.Cells[row + 1, col + 1];
                setCellValue();
            }
           
            //cell.FormulaR1C1 = string.Format();
        }

        public async Task<byte[]> CreateSheetsAsync(List<Jh.Abp.Document.Excel.Models.SheetDto> sheets)
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

                    workSheet.Cells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    workSheet.Cells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    workSheet.Cells.Style.WrapText = true;//自动换行
                    workSheet.Cells.AutoFitColumns(20,100);
                }
                return await package.GetAsByteArrayAsync();
            }
        }
    }
}
