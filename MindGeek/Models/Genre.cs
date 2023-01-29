using System.ComponentModel.DataAnnotations;

namespace MindGeek.Models
{
    public class Genre
    {
        [Required]
        public string Name { get; set; } = default!;
    }
}
