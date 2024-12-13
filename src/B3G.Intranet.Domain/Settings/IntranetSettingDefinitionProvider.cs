using Volo.Abp.Settings;

namespace B3G.Intranet.Settings;

public class IntranetSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(IntranetSettings.MySetting1));
    }
}
