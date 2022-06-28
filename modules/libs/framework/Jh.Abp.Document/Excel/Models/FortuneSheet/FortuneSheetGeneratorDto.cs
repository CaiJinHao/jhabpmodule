using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.Document.Excel
{
    public class FortuneSheetGeneratorDto
    {
        public int rs { get; set; }
        public int cs { get; set; }

        public List<CellDto> Cells { get; set; } = new List<CellDto>();

        public int Getrs()
        {
            return rs == 0 ? 1 : rs;
        }

        public int Getcs()
        {
            return cs == 0 ? 1 : cs;
        }
    }
}
