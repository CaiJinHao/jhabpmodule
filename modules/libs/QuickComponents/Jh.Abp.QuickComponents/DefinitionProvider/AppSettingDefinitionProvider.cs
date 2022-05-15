using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Localization;
using Volo.Abp.Settings;
using Volo.Abp.Timing;

namespace Jh.Abp.QuickComponents
{
    public class AppSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            // var timing = context.GetOrNull(TimingSettingNames.TimeZone);
            // if (timing != null)
            // {
            //     timing.DefaultValue = "LOCAL";//Local不能用，/api/abp/application-configuration会报错
            // }
        }
    }
}
