using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace B3G.Intranet.Projects
{
    public class Project : AuditedAggregateRoot<Guid>
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
