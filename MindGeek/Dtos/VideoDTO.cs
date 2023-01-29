namespace MindGeek.Models
{
    public record VideoDTO
    {
        public string Title { get; init; } = default!;
        public List<AlternativeDTO> Alternatives { get; init; } = default!;
        public string Type { get; init; } = default!;
        public Uri Url { get; init; } = default!;
    }
}