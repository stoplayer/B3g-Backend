using System.ComponentModel.DataAnnotations;

namespace B3G.Intranet.Clients
{
    public class CreateUpdateClientDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; } = string.Empty;
    }
}
