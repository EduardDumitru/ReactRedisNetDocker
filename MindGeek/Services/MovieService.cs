using Mapster;
using MapsterMapper;
using MindGeek.Extensions;
using MindGeek.Models;
using MindGeek.Repositories;
using System.Net;

namespace MindGeek.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;
        private readonly IMovieRepo _movieRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<MovieService> _logger;
        public MovieService(IMovieRepo movieRepo, IMapper mapper, HttpClient httpClient, ILogger<MovieService> logger)
        {
            _movieRepo = movieRepo;
            _mapper = mapper;
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task CreateMovie(MovieDTO movie)
        {
            var adaptedMovie = _mapper.From(movie).AdaptToType<Movie>();
            await _movieRepo.CreateMovie(adaptedMovie);
        }

        public async Task CreateMovies(List<MovieDTO> movies)
        {
            var adaptedMovies = _mapper.From(movies).AdaptToType<List<Movie>>();

            await MapImagesToMovieList(movies, adaptedMovies);

            await _movieRepo.CreateMovies(adaptedMovies);
        }

        public async Task<MovieDTO> GetMovieById(string id)
        {
            return _mapper.From(await _movieRepo.GetMovieById(id)).AdaptToType<MovieDTO>();
        }

        public async Task<List<MovieDTO>> GetMovies()
        {
            return _mapper.From(await _movieRepo.GetMovies()).AdaptToType<List<MovieDTO>>();
        }

        private async Task MapImagesToMovieList(List<MovieDTO> movies, List<Movie> adaptedMovies)
        {
            for (int i = 0; i < movies.Count; i++)
            {
                await MapImagesToMovie(movies[i], adaptedMovies[i]);
            }
        }

        private async Task MapImagesToMovie(MovieDTO movie, Movie adaptedMovie)
        {
            for (int i = 0; i < movie.KeyArtImages.Count; i++)
            {
                try
                {
                    adaptedMovie.KeyArtImages[i].Image = await _httpClient.GetByteArrayAsync(movie.KeyArtImages[i].Url);
                    SetImageExtension(adaptedMovie.KeyArtImages[i]);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error {Message} encountered at {Url}", ex.Message, movie.KeyArtImages[i].Url);
                }
            }

            for (int i = 0; i < movie.CardImages.Count; i++)
            {
                try
                {
                    adaptedMovie.CardImages[i].Image = await _httpClient.GetByteArrayAsync(movie.CardImages[i].Url);
                    SetImageExtension(adaptedMovie.CardImages[i]);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error {Message} encountered at {Url}", ex.Message, movie.CardImages[i].Url);
                }
            }
        }

        private static void SetImageExtension(CardImage image)
        {
            var fileExtension = image.Image.TryGetExtension();
            image.Extension = fileExtension ?? string.Empty;
        }
    }
}
