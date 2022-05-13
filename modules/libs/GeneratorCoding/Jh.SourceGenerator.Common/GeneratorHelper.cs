using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Jh.Abp.Common;

namespace Jh.SourceGenerator.Common
{
    public class GeneratorHelper
    {
        public static ProxyServiceModelCodeBuilder CreateProxyServiceModelCodeBuilder(Type modelType, string filePath)
        {
            var type = modelType.GetRealTypeValue();
            if (!type.IsValueType
                && type.BaseType != null
                && !new Regex($"({nameof(Task)})|({nameof(String)})").IsMatch(type.Name)//排除生成Model的类型
                )
            {
                return new ProxyServiceModelCodeBuilder(type, filePath);
            }
            return null;
        }
    }
}
