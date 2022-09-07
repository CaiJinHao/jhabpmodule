using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jh.Abp.QuickComponents
{
    public static class AppUtils
    {
        public static IConfiguration GetLogBuildConfiguration(string file, bool optional = false)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(file, optional: optional);
            return builder.Build();
        }
    }
}
