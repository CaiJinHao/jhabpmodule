using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Jh.Abp.QuickComponents
{
    /*
    找到请求的语言之后，优先使用cookies中的,cookies中未设置，才按照浏览器设置的默认语言，edge 请添加中文(简体)
    
浏览器(如Chrome)的值为zh-CN
而ABP的简体中文的值为zh-Hans
解决的办法也很简单:
    app.UseAbpRequestLocalization(options =>
            {
                options.RequestCultureProviders.RemoveAll(provider => provider is Microsoft.AspNetCore.Localization.AcceptLanguageHeaderRequestCultureProvider);
            });
    这样修改后, ABP就会忽略浏览器发送的accept-language值, 从而使我们的默认设置生效. (别忘了清除浏览器的Cookie缓存)
    ASP.NET Core的本地化机制中会维护一个RequestCultureProvider的列表, 默认列表中有三个值:

1、QueryStringRequestCultureProvider : 通过URL中的查询字符串确定Culture
2、CookieRequestCultureProvider : 通过Cookie确定Culture
3、AcceptLanguageHeaderRequestCultureProvider : 通过浏览器发送的accept-header确定Culture
这个列表的优先级为从上到下, 也就是说如果通过查询字符串提供了Culture, 那么剩下的Provider就不会有生效.
4、而ABP的语言默认值, 只有列表中所有的Provider都未命中才会生效.例如：Postman发送的请求，使用的是默认语言
解决方法：加自定义 CustomRequestCultureProvider

你可以试一下通过在URL后加上?culture=zh-Hans, 这样会强制使用简体中文, 因为QueryString是优先级最高的
同理, Cookie是第2高的, 所以上面让你清除浏览器Cookie, 以免影响默认值
上面的解决方法的思路就是, 把第3个AcceptLanguageHeaderRequestCultureProvider从列表中删除了, 从而让默认语言值生效.


     */
    public class JhSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            var defaultLanguage = context.GetOrNull(LocalizationSettingNames.DefaultLanguage);
            if (defaultLanguage != null)
            {
                defaultLanguage.DefaultValue = "zh-Hans";//设置为默认使用中文(简体)
            }
        }
    }
}
