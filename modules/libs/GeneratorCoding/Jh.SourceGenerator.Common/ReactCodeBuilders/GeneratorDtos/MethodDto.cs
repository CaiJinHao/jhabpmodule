using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Jh.Abp.Common;

namespace Jh.SourceGenerator.Common.ReactCodeBuilders
{
    public class MethodDto
    {
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public string RequestMethod { get; set; }
        public string RouteUrl { get; set; }
        public Dictionary<string, Type> Parameters { get; set; } = new Dictionary<string, Type>();
        public string GetParameters(string moduleNamespace)
        {
            //转为js类型
            //判断类型是否需要添加命名空间
            return string.Join(",", Parameters.Select(a => {
                var jsVarType = a.Value.Name.FormatJsVar();
                if (a.Value.IsModelType())
                {
                    jsVarType = $"{moduleNamespace}.{jsVarType}";
                }
                else
                {
                    jsVarType = jsVarType.ToCamelCase(CamelCaseType.LowerCamelCase);
                }
                return $"{a.Key}: {jsVarType}";
            }));
        }
        public string GetParameterKeys()
        {
            return string.Join(",", Parameters.Select(a => a.Key));
        }
    }

    public class ControllerDto
    {
        public string Name { get;}
        public string ModuleNamespace { get; set; }
        public string GlobalNamespace { get; set; }
        public List<MethodDto> MethodDtos { get; set; } = new List<MethodDto>();
        public ControllerDto(string name, string moduleNamespace,string globalNamespace)
        {
            Name = name;
            ModuleNamespace = moduleNamespace;
            GlobalNamespace = globalNamespace;
        }
    }
}
