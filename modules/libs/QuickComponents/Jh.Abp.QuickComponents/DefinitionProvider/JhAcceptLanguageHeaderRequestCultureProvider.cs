using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jh.Abp.QuickComponents
{
    public class JhAcceptLanguageHeaderRequestCultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            var acceptLanguageHeader = httpContext.Request.GetTypedHeaders().AcceptLanguage;

            if (acceptLanguageHeader == null || acceptLanguageHeader.Count == 0)
            {
                return NullProviderCultureResult;
            }

            var languages = acceptLanguageHeader.AsEnumerable();

            var orderedLanguages = languages.OrderByDescending(h => h, StringWithQualityHeaderValueComparer.QualityComparer)
                .Select(x => x.Value).ToList();

            if (orderedLanguages.Count > 0)
            {
                var cultures = new HashSet<StringSegment>();
                foreach (var item in orderedLanguages)
                {
                    switch (item.Value)
                    {
                        case "zh":
                        case "zh-CN":
                            {
                                //中文简体
                                cultures.Add(new StringSegment("zh-Hans"));
                            }break;
                        case "zh-TW":
                        case "zh-HK":
                            {
                                //中文繁体
                                cultures.Add(new StringSegment("zh-Hant"));
                            }
                            break;
                        default:
                            cultures.Add(item);
                            break;
                    }
                }
                return Task.FromResult(new ProviderCultureResult(cultures.ToArray()));
            }

            return NullProviderCultureResult;
        }
    }
}
