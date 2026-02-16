using GM.Contracts.Queries;
using GM.Contracts.Queries.Movies;
using GM.WebApi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GM.WebApi.Controllers;

[Route("api/movies")]
public class MoviesController(IQueryDispatcher queryDispatcher) : ControllerBase
{
    private readonly IQueryDispatcher queryDispatcher = queryDispatcher;

    [HttpGet]
    [Route("popular")]
    public async Task<IActionResult> GetPopularMovies(CancellationToken cancellation)
    {
        var movies = await this.queryDispatcher.ExecuteAsync<PopularMoviesQuery, MoviesQueryResponse>(
            new PopularMoviesQuery(),
            cancellation);

        return Ok(new MoviesResponse { Movies = movies.Movies });
    }
}
