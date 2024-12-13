using System;
using Volo.Abp.Application.Dtos;

namespace B3G.Intranet.Projects
{
    public class ProjectDto : AuditedEntityDto<Guid>
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
