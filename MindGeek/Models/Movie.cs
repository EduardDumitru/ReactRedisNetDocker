using Mapster;
using System.ComponentModel.DataAnnotations;

namespace MindGeek.Models
{
    public class Movie
    {
        [Required]
        public string Id { get; set; } = default!;
        public string Body { get; set; } = default!;
        public List<CardImage> CardImages { get; set; } = default!;
        public List<Actor> Cast { get; set; } = default!;
        public string Cert { get; set; } = default!;
        public string Class { get; set; } = default!;
        public List<Director> Directors { get; set; } = default!;
        public int Duration { get; set; } = default!;
        public List<string> Genres { get; set; } = default!;
        public string Headline { get; set; } = default!;
        public List<CardImage> KeyArtImages { get; set; } = default!;
        public DateTime LastUpdated { get; set; } = default!;
        public string Quote { get; set; } = default!;
        public int Rating { get; set; } = default!;
        public string ReviewAuthor { get; set; } = default!;
        public string SkyGoId { get; set; } = default!;
        public Uri SkyGoUrl { get; set; } = default!;
        public string Sum { get; set; } = default!;
        public string Synopsis { get; set; } = default!;
        public Uri Url { get; set; } = default!;
        public List<Video> Videos { get; set; } = default!;
        public ViewingWindow ViewingWindow { get; set; } = default!;
        public int Year { get; set; } = default!;
    }
}
