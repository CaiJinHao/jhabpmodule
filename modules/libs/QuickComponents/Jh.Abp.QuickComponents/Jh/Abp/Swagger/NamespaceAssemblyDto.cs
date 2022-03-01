using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jh.Abp.QuickComponents
{
    /// <summary>
    /// 所依赖模块的Swagger文档注释加载
    /// </summary>
    public  class NamespaceAssemblyDto
    {
        /// <summary>
        /// 对应程序集得命名空间
        /// </summary>
        public string BaseNamespace { get; set; }
        /// <summary>
        /// xml注释程序集
        /// </summary>
        public Assembly AssemblyXmlComments { get; set; }
    }
}
