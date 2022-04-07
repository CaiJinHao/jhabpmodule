using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jh.Abp.QuickComponents
{
    public  class SwaggerApiOptions
    {
        public string DocumentTitle { get; set; }
        public string RoutePrefix { get; set; }
        public SwaggerApiInfo[] OpenApiInfos { get; set; }
    }

    public class SwaggerApiInfo: Microsoft.OpenApi.Models.OpenApiInfo
    {
        public string GroupName { get; set; }
        public string SwaggerEndpointName { get; set; }
    }
}
