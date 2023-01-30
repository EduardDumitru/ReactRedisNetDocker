namespace MindGeek.Dtos
{
    public record CardImageToAddDTO
    {
        public Uri Url { get; init; } = default!;
        public int H { get; init; } = default!;
        public int W { get; init; } = default!;
    }
}
