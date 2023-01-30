namespace MindGeek.Dtos
{
    public record CardImageDTO
    {
        public byte[] Image { get; init; } = default!;
        public int H { get; init; } = default!;
        public int W { get; init; } = default!;
        public string Extension { get; init; } = default!;
    }
}