using System.ComponentModel.DataAnnotations;

namespace SewaPatra.Models
{
    public class Area
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Area_name { get; set; }
        [Required]
        public string Area_type { get; set; }
	    public string? Under { get; set; }

    }
}
