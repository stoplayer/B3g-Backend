using B3G.Intranet.Localization;
using Volo.Abp.Application.Services;

namespace B3G.Intranet;

/* Inherit your application services from this class.
 */
public abstract class IntranetAppService : ApplicationService
{
    protected IntranetAppService()
    {
        LocalizationResource = typeof(IntranetResource);
    }
}
