using System.Threading.Tasks;

namespace B3G.Intranet.Data;

public interface IIntranetDbSchemaMigrator
{
    Task MigrateAsync();
}
