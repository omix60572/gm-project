using GM.Contracts.Queries;
using GM.Contracts.Queries.Movies;
using GM.WebApi.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace GM.WebApi.Controllers;

[Route("movie")]
public class MovieController(IQueryDispatcher queryDispatcher) : ControllerBase
{
    private readonly IQueryDispatcher queryDispatcher = queryDispatcher;

    [HttpGet]
    [Route("{movieId}")]
    public async Task<IActionResult> GetMovieById(int movieId, CancellationToken cancellation)
    {
        var movie = await this.queryDispatcher.ExecuteAsync<MovieQuery, MovieQueryResponse>(new MovieQuery() { Id = movieId }, cancellation);
        return Ok(new MovieResponse { Movie = movie.Movie });
    }
}
