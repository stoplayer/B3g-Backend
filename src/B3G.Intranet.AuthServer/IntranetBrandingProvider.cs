using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace B3G.Intranet;

[Dependency(ReplaceServices = true)]
public class IntranetBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Intranet";
}
