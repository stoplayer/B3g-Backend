using System;
using Volo.Abp.Application.Dtos;

namespace B3G.Intranet.CRAs
{
    public class CRADto : AuditedEntityDto<Guid>
    {
        public Guid TaskId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime TimeStamp { get; set; }
        public float TimeSpent { get; set; }
    }
}
