using MindGeek.Models;

namespace MindGeek.Services
{
    public interface IMovieService
    {
        Task CreateMovie(MovieDTO movie);
        Task<MovieDTO> GetMovieById(string id);
        Task<List<MovieDTO>> GetMovies();
        Task CreateMovies(List<MovieDTO> movies);
    }
}
