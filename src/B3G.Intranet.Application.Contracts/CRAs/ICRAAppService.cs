using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace B3G.Intranet.CRAs
{
    public interface ICRAAppService :
        ICrudAppService<
                CRADto,
                Guid,
                PagedAndSortedResultRequestDto,
                CreateUpdateCRADto>
    {

    }
}