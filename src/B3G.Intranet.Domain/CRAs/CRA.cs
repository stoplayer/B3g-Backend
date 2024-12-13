using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace B3G.Intranet.CRAs
{
    public class CRA : AuditedAggregateRoot<Guid>
    {
        public Guid TaskId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime TimeStamp { get; set; }
        public float TimeSpent { get; set; }
    }
}
