using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace B3G.Intranet.Clients
{
    public class Client : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
    }
}
