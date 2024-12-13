using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace B3G.Intranet.CRAs
{
    public class CRAAppService :
    CrudAppService<
            CRA,
            CRADto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateCRADto>,
        ICRAAppService
    {
        public CRAAppService(IRepository<CRA, Guid> repository)
            : base(repository)
        {

        }
    }
}