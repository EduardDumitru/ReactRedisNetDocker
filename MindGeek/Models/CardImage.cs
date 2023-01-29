using System.ComponentModel.DataAnnotations;

namespace MindGeek.Models
{
    public class CardImage
    {
        [Required]
        public byte[] Image { get; set; } = default!;
        [Required]
        public int H { get; set; } = default!;
        [Required]
        public int W { get; set; } = default!;
        [Required]
        public string Extension { get; set; } = default!;
    }
}
