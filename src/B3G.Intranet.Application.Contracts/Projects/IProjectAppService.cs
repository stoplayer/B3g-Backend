using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using B3G.Intranet.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace B3G.Intranet.Projects
{
    public interface IProjectAppService :
        ICrudAppService<
                ProjectDto,
                Guid,
                PagedAndSortedResultRequestDto,
                CreateUpdateProjectDto>
    {
        Task<List<TaskDto>> GetTasksByProjectIdAsync(Guid projectId);
    }
}