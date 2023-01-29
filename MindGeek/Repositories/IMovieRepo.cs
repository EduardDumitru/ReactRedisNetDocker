using MindGeek.Models;

namespace MindGeek.Repositories
{
    public interface IMovieRepo
    {
        Task CreateMovie(Movie movie);
        Task CreateMovies(List<Movie> movies);
        Task<Movie?> GetMovieById(string id);
        Task<ICollection<Movie>> GetMovies();
    }
}
