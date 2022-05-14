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
        private static Dictionary<string, ProxyServiceModelCodeBuilder> ProxyServiceModelCodeBuilders { get; set; }
        public static Dictionary<string, ProxyServiceModelCodeBuilder> GetProxyServiceModelCodeBuilders()
        { 
            return ProxyServiceModelCodeBuilders;
        }
        /// <summary>
        /// 目前是每生成一个service，初始化一次，目的：每个service的dto放在一起
        /// </summary>
        public static void InitialProxyServceModelCodeBuilders()
        {
            ProxyServiceModelCodeBuilders = new Dictionary<string, ProxyServiceModelCodeBuilder>();
        }

        public static void AddProxyServiceModelCodeBuilder(Type modelType)
        {
            var type = modelType.GetRealTypeValue();
            if (!type.IsValueType
                && type.BaseType != null
                && !new Regex($"({nameof(Task)})|({nameof(String)})").IsMatch(type.Name)//排除生成Model的类型
                )
            {
                if (!ProxyServiceModelCodeBuilders.ContainsKey(type.Name))
                {
                    ProxyServiceModelCodeBuilders.Add(type.Name, null);
                    ProxyServiceModelCodeBuilders[type.Name] = new ProxyServiceModelCodeBuilder(type);
                }
            }
        }
    }
}
