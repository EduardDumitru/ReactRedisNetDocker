using Mapster;
using MapsterMapper;
using MindGeek.Dtos;
using MindGeek.Repositories;
using MindGeek.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o => o.AddPolicy("AllowAll", x =>
{
    x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var config = new TypeAdapterConfig();
builder.Services.AddSingleton(config);
builder.Services.AddTransient<IMapper, Mapper>();

builder.Services.AddSingleton<IConnectionMultiplexer>(_ =>
    ConnectionMultiplexer.Connect(new ConfigurationOptions
    {
        EndPoints = { builder.Configuration.GetConnectionString("RedisConnection") },
        AbortOnConnectFail = false
    }, Console.Out)

);
builder.Services.AddTransient<IMovieRepo, RedisMovieRepo>();
builder.Services.AddHttpClient<IMovieService, MovieService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/movie", async (MovieToAddDTO movie, IMovieService _movieService) =>
{
    try
    {
        await _movieService.CreateMovie(movie);
        return Results.Created("/movie", movie);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithName("CreateMovie");

app.MapPost("/movie/multiple", async (List<MovieToAddDTO> movies, IMovieService _movieService) =>
{
    try
    {
        await _movieService.CreateMovies(movies);
        return Results.Created("/movie/multiple", movies);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithName("CreateMovies");

app.MapGet("/movie/{id}", async (string id, IMovieService _movieService) =>
{
    try
    {
        return await _movieService.GetMovieById(id) is MovieDTO movie ? Results.Ok(movie) : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }

}).WithName("GetMovieById");

app.MapGet("/movie/all", async (IMovieService _movieService) =>
{
    try
    {
        return await _movieService.GetMovies() is List<MovieDTO> movies ? Results.Ok(movies) : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithName("GetMovies");

app.UseCors("AllowAll");

app.Run();