using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Jh.Abp.QuickComponents
{
    /// <summary>
    /// 此过滤器会将所有方法添加授权验证，如果需要某些方法不进行授权请手动过滤或添加表达式过滤
    /// </summary>
    [Obsolete("不建议使用，请移步使用授权策略验证或者手动添加特性,添加对url得过滤，nginx转发挡再外面了")]
    public class JhAuthorizationFilter : AuthorizeFilter
    {
        public IConfiguration Configuration;
        /// <summary>
        /// 此过滤器会将所有方法添加授权验证，如果需要某些方法不进行授权请手动过滤或添加表达式过滤
        /// </summary>
        /// <param name="policy"></param>
        /// <param name="configuration"></param>
        public JhAuthorizationFilter(AuthorizationPolicy policy, IConfiguration configuration) : base(policy)
        {
            Configuration = configuration;
        }

        public override Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var allowAnonymousRegexStr = Configuration["App:AllowAnonymousRegex"];
            if (allowAnonymousRegexStr != null)
            {
                var allowAnonymousRegexs = allowAnonymousRegexStr.Split(",", StringSplitOptions.RemoveEmptyEntries);
                if (allowAnonymousRegexs.Length > 0)
                {
                    var path = context.HttpContext.Request.Path.Value;
                    if (path != null && path.Length > 0)
                    {
                        if (allowAnonymousRegexs.Any(a => new Regex(a).IsMatch(path)))
                        {
                            return Task.CompletedTask;
                        }
                    }
                }
            }
            return base.OnAuthorizationAsync(context);
        }
    }
}
