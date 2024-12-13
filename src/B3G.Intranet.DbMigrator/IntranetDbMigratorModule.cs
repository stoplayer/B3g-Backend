using B3G.Intranet.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace B3G.Intranet.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(IntranetEntityFrameworkCoreModule),
    typeof(IntranetApplicationContractsModule)
)]
public class IntranetDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options =>
        {
            options.IsJobExecutionEnabled = false;
        });
    }
}
