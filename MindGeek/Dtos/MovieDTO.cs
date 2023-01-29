using Mapster;

namespace MindGeek.Models
{
    public record MovieDTO
    {
        public string Id { get; init; } = default!;
        public string Body { get; init; } = default!;
        public List<CardImageDTO> CardImages { get; init; } = default!;
        public List<ActorDTO> Cast { get; init; } = default!;
        public string Cert { get; init; } = default!;
        public string Class { get; init; } = default!;
        public List<DirectorDTO> Directors { get; init; } = default!;
        public int Duration { get; init; } = default!;
        public List<string> Genres { get; init; } = default!;
        public string Headline { get; init; } = default!;
        public List<CardImageDTO> KeyArtImages { get; init; } = default!;
        public DateTime LastUpdated { get; init; } = default!;
        public string Quote { get; init; } = default!;
        public int Rating { get; init; } = default!;
        public string ReviewAuthor { get; init; } = default!;
        public string SkyGoId { get; init; } = default!;
        public Uri SkyGoUrl { get; init; } = default!;
        public string Sum { get; init; } = default!;
        public string Synopsis { get; init; } = default!;
        public Uri Url { get; init; } = default!;
        public List<VideoDTO> Videos { get; init; } = default!;
        public ViewingWindowDTO ViewingWindow { get; init; } = default!;
        public int Year { get; init; } = default!;
    }
}
