using System;
using System.ComponentModel.DataAnnotations;

namespace B3G.Intranet.Tasks
{
    public class CreateUpdateTaskDto
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(2048)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime EstimatedEndDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}
