using System.ComponentModel.DataAnnotations;

namespace MindGeek.Models
{
    public class Video
    {
        public string Title { get; set; } = default!;
        public List<AlternativeDTO> Alternatives { get; set; } = default!;
        public string Type { get; set; } = default!;
        public Uri Url { get; set; } = default!;
    }
}
