using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace B3G.Intranet.Data;

/* This is used if database provider does't define
 * IIntranetDbSchemaMigrator implementation.
 */
public class NullIntranetDbSchemaMigrator : IIntranetDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
