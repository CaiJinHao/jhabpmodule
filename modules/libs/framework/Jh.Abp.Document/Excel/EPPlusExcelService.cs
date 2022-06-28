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
                                workSheet.SetValue(row + 1, col + 1, dataCell["v"].ToString());
                            }
                        }
                    }

                }

                return await package.GetAsByteArrayAsync();
            }
        }
    }
}
