using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;

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
            using (var package = new ExcelPackage())
            {
                var sheetDataCells = sheet.data;
                var workSheet = package.Workbook.Worksheets.Add(sheet.name);

                for (int row = 0; row < sheetDataCells.GetLength(0); row++)
                {
                    for (int col = 0; col < sheetDataCells.GetLength(1); col++)
                    {
                        var dataCell = sheetDataCells[row, col] as JObject;
                        workSheet.SetValue(row, col, dataCell["v"]);
                    }
                }
            }
        }

        public void CreateSheetsAsync(List<Jh.Abp.Document.Excel.Models.SheetDto> sheets)
        {
            foreach (var item in sheets)
            {
                CreateSheetAsync(item);
            }
        }
    }
}
