using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using B3G.Intranet.Projects;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace B3G.Intranet.Clients
{
    public class ClientAppService :
        CrudAppService<
            Client,
            ClientDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateClientDto>,
        IClientAppService
    {
        private readonly IRepository<Project, Guid> _projectRepository;

        public ClientAppService(IRepository<Client, Guid> repository, IRepository<Project, Guid> projectRepository)
            : base(repository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectDto>> GetProjectsByClientIdAsync(Guid clientId)
        {
            var projects = await _projectRepository.GetListAsync(p => p.ClientId == clientId);
            return ObjectMapper.Map<List<Project>, List<ProjectDto>>(projects);
        }
    }
}