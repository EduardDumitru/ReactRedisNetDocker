using MindGeek.Dtos;

namespace MindGeek.Services
{
    public interface IMovieService
    {
        Task CreateMovie(MovieToAddDTO movie);
        Task<MovieDTO> GetMovieById(string id);
        Task<List<MovieDTO>> GetMovies();
        Task CreateMovies(List<MovieToAddDTO> movies);
    }
}
