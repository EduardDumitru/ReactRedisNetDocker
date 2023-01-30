namespace MindGeek.Dtos
{
    public record MovieToAddDTO
    {
        public List<CardImageToAddDTO> CardImages { get; init; } = default!;
        public List<CardImageToAddDTO> KeyArtImages { get; init; } = default!;
    }
}
