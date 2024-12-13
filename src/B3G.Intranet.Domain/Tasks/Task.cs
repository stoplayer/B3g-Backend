using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace B3G.Intranet.Tasks
{
    public class TaskItem : AuditedAggregateRoot<Guid>
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }

    }
}
