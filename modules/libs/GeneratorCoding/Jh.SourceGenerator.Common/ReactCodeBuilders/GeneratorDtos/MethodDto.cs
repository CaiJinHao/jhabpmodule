using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Jh.SourceGenerator.Common.ReactCodeBuilders
{
    public class MethodDto
    {
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public string RequestMethod { get; set; }
        public string RouteUrl { get; set; }
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        public string GetParameters()
        {
            
            return string.Join(",", Parameters.Select(a => $"{a.Key}:{a.Value}"));
        }
        public string GetParameterKeys()
        {
            return string.Join(",", Parameters.Select(a => a.Key));
        }
    }

    public class ControllerDto
    {
        public string Name { get;}
        public List<MethodDto> MethodDtos { get; set; } = new List<MethodDto>();
        public ControllerDto(string name)
        {
            Name = name;
        }
    }
}
