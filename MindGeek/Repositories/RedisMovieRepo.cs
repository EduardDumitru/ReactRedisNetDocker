using MindGeek.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace MindGeek.Repositories
{
    public class RedisMovieRepo : IMovieRepo
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisMovieRepo(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public async Task CreateMovie(Movie movie)
        {
            var db = _redis.GetDatabase();

            var serialMovie = JsonSerializer.Serialize(movie);

            await db.StringSetAsync(movie.Id, serialMovie);
            await db.SetAddAsync("MovieSet", serialMovie);
        }

        public async Task CreateMovies(List<Movie> movies)
        {
            foreach (var movie in movies)
            {
                await CreateMovie(movie);
            }
        }

        public async Task<ICollection<Movie>> GetMovies()
        {
            var db = _redis.GetDatabase();

            var movies = await db.SetMembersAsync("MovieSet");

            return movies.Select(mov => JsonSerializer.Deserialize<Movie>(mov)!).ToList();
        }

        public async Task<Movie?> GetMovieById(string id)
        {
            var db = _redis.GetDatabase();

            var movie = await db.StringGetAsync(id);

            if (!string.IsNullOrWhiteSpace(movie))
            {
                return JsonSerializer.Deserialize<Movie>(movie)!;
            }

            return null;
        }
    }
}
