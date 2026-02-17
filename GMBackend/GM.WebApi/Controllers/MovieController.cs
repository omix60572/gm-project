using GM.Contracts.Queries;
using GM.Contracts.Queries.Movies;
using GM.WebApi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GM.WebApi.Controllers;

[Route("api/movie")]
public class MovieController : BaseController
{
    private readonly IQueryDispatcher queryDispatcher;

    public MovieController(IQueryDispatcher queryDispatcher) =>
        this.queryDispatcher = queryDispatcher;

    [HttpGet]
    [Route("{movieId}")]
    public async Task<IActionResult> GetMovieById(int movieId, CancellationToken cancellation)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var movie = await this.queryDispatcher.ExecuteAsync<MovieQuery, MovieQueryResponse>(
            new MovieQuery { Id = movieId },
            cancellation);

        return Ok(new MovieResponse { Movie = movie.Movie });
    }
}
