using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using B3G.Intranet.Projects;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace B3G.Intranet.Clients
{
    public interface IClientAppService :
        ICrudAppService<
                ClientDto,
                Guid,
                PagedAndSortedResultRequestDto,
                CreateUpdateClientDto>
    {
        Task<List<ProjectDto>> GetProjectsByClientIdAsync(Guid clientId);
    }
}