using System;
using System.ComponentModel.DataAnnotations;

namespace B3G.Intranet.CRAs
{
    public class CreateUpdateCRADto
    {
        [Required]
        public Guid TaskId { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeStamp { get; set; } = DateTime.Now;

        [Required]
        public float TimeSpent { get; set; }
    }
}
