using B3G.Intranet.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace B3G.Intranet.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class IntranetController : AbpControllerBase
{
    protected IntranetController()
    {
        LocalizationResource = typeof(IntranetResource);
    }
}
