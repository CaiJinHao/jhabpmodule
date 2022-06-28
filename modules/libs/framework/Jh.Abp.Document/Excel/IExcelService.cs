using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Jh.Abp.Document.Excel
{
    public interface IExcelService
    {
        /// <summary>
        /// 根据二维表格创建
        /// </summary>
        /// <param name="sheets"></param>
        /// <returns></returns>
        public Task<byte[]> CreateSheetsByDoubleArrayAsync(List<Jh.Abp.Document.Excel.Models.SheetDto> sheets);
        /// <summary>
        /// 根据一味对象创建
        /// </summary>
        /// <param name="sheets"></param>
        /// <returns></returns>
        public Task<byte[]> CreateSheetsAsync(List<Jh.Abp.Document.Excel.Models.SheetDto> sheets);
    }
}
