using Volo.Abp.Settings;

namespace YourCompany.YourProjectName.Settings;

public class YourProjectNameSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(YourProjectNameSettings.MySetting1));
    }
}
