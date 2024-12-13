using System;
using Volo.Abp.Application.Dtos;

namespace B3G.Intranet.Tasks
{
    public class TaskDto : AuditedEntityDto<Guid>
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
    }
}
