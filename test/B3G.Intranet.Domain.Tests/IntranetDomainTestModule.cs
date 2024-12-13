using B3G.Intranet.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace B3G.Intranet;

[DependsOn(
    typeof(IntranetEntityFrameworkCoreTestModule)
    )]
public class IntranetDomainTestModule : AbpModule
{

}
