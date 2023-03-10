namespace MindGeek.Dtos
{
    public record AlternativeDTO
    {
        public string Quality { get; init; } = default!;
        public Uri Url { get; init; } = default!;
    }
}