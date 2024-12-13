using Volo.Abp.Modularity;

namespace B3G.Intranet;

[DependsOn(
    typeof(IntranetApplicationModule),
    typeof(IntranetDomainTestModule)
    )]
public class IntranetApplicationTestModule : AbpModule
{

}
