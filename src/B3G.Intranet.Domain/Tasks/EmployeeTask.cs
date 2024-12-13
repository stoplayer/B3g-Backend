using System;
using Volo.Abp.Domain.Entities;

namespace B3G.Intranet.Tasks
{
    public class EmployeeTask : Entity
    {
        public Guid TaskId { get; set; }

        public Guid EmployeeId { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { TaskId, EmployeeId };
        }
    }
}
