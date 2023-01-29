using Mapster;
using System.ComponentModel.DataAnnotations;

namespace MindGeek.Models
{
    public class Actor
    {
        [Required]
        public string Name { get; set; } = default!;
    }
}
