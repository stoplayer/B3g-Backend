using AutoMapper;
using B3G.Intranet.Clients;
using B3G.Intranet.CRAs;
using B3G.Intranet.Projects;
using B3G.Intranet.Tasks;

namespace B3G.Intranet;

public class IntranetApplicationAutoMapperProfile : Profile
{
    public IntranetApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Client, ClientDto>();
        CreateMap<Project, ProjectDto>();
        CreateMap<TaskItem, TaskDto>();
        CreateMap<CRA, CRADto>();

        CreateMap<CreateUpdateClientDto, Client>();
        CreateMap<CreateUpdateProjectDto, Project>();
        CreateMap<CreateUpdateTaskDto, TaskItem>();
        CreateMap<CreateUpdateCRADto, CRA>();

    }
}
