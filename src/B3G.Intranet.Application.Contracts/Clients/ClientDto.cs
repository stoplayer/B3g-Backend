using System;
using Volo.Abp.Application.Dtos;

namespace B3G.Intranet.Clients
{
    public class ClientDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
    }
}