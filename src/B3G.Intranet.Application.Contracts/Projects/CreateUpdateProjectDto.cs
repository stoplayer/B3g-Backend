using System;
using System.ComponentModel.DataAnnotations;

namespace B3G.Intranet.Projects
{
    public class CreateUpdateProjectDto
    {

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; } = string.Empty;

        [StringLength(2048)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Budget { get; set; }

        [Required]
        public DateTime EstimatedEndDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
