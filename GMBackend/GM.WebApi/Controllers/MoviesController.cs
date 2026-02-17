using GM.Contracts.Queries;
using GM.Contracts.Queries.Movies;
using GM.WebApi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GM.WebApi.Controllers;

[Route("api/movies")]
public class MoviesController : BaseController
{
    private const int MaxIdentifiersCount = 1000;

    private readonly IQueryDispatcher queryDispatcher;

    public MoviesController(IQueryDispatcher queryDispatcher) =>
        this.queryDispatcher = queryDispatcher;

    [HttpGet]
    [Route("popular")]
    public async Task<IActionResult> GetPopularMovies(CancellationToken cancellation)
    {
        var movies = await this.queryDispatcher.ExecuteAsync<PopularMoviesQuery, MoviesQueryResponse>(
            new PopularMoviesQuery(),
            cancellation);

        return Ok(new MoviesResponse { Movies = movies.Movies });
    }

    [HttpGet]
    [Route("getmovies")]
    public async Task<IActionResult> GetMovies([FromBody]List<long> Ids, CancellationToken cancellation)
    {
        if (!ModelState.IsValid || Ids.Count >= MaxIdentifiersCount)
            return BadRequest();

        var movies = await this.queryDispatcher.ExecuteAsync<MoviesQuery, MoviesQueryResponse>(
            new MoviesQuery { Ids = Ids },
            cancellation);

        return Ok(new MoviesResponse { Movies = movies.Movies });
    }
}
