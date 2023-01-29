using System.ComponentModel.DataAnnotations;

namespace MindGeek.Models
{
    public class Director
    {
        [Required]
        public string Name { get; set; } = default!;
    }
}
