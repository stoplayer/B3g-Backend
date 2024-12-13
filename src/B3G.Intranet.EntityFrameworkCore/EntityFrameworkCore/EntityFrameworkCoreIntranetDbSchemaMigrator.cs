using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using B3G.Intranet.Data;
using Volo.Abp.DependencyInjection;

namespace B3G.Intranet.EntityFrameworkCore;

public class EntityFrameworkCoreIntranetDbSchemaMigrator
    : IIntranetDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreIntranetDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the IntranetDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<IntranetDbContext>()
            .Database
            .MigrateAsync();
    }
}
