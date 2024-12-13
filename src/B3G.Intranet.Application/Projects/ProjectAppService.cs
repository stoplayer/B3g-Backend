using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using B3G.Intranet.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace B3G.Intranet.Projects
{
    public class ProjectAppService :
        CrudAppService<
            Project,
            ProjectDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateProjectDto>,
        IProjectAppService
    {
        public readonly IRepository<TaskItem, Guid> _taskRepository;

        public ProjectAppService(IRepository<Project, Guid> repository, IRepository<TaskItem, Guid> taskRepository)
            : base(repository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskDto>> GetTasksByProjectIdAsync(Guid projectId)
        {
            var tasks = await _taskRepository.GetListAsync(t => t.ProjectId == projectId);
            return ObjectMapper.Map<List<TaskItem>, List<TaskDto>>(tasks);
        }

    }
}