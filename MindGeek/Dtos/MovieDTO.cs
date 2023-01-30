namespace MindGeek.Dtos
{
    public record MovieDTO : DefaultMovieDTO
    {
        public List<CardImageDTO> CardImages { get; init; } = default!;
        public List<CardImageDTO> KeyArtImages { get; init; } = default!;
    }
}
