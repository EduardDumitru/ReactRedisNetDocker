using System.ComponentModel.DataAnnotations;

namespace MindGeek.Models
{
    public class Alternative
    {
        [Required]
        public string Quality { get; set; } = default!;
        [Required]
        public Uri Url { get; set; } = default!;
    }
}
