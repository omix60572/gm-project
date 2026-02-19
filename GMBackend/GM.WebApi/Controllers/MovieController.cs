using GM.Contracts.Commands;
using GM.Contracts.Commands.Movies;
using GM.Contracts.Models;
using GM.Contracts.Queries;
using GM.Contracts.Queries.Movies;
using GM.WebApi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GM.WebApi.Controllers;

[Route("api/movie")]
public class MovieController : BaseController
{
    private readonly IQueryDispatcher queryDispatcher;
    private readonly ICommandDispatcher commandDispatcher;

    public MovieController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
    {
        this.queryDispatcher = queryDispatcher;
        this.commandDispatcher = commandDispatcher;
    }

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

    [HttpPost]
    [Route("addmovie")]
    public async Task<IActionResult> AddMovie([FromBody]MovieModel movie, CancellationToken cancellation)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var addCommand = new AddNewMovieCommand
        {
            movie = movie
        };
        await this.commandDispatcher.ExecuteAsync(addCommand, cancellation);

        return Ok();
    }
}
