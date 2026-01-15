using GM.Contracts.Models;
using GM.Contracts.Queries;
using GM.Contracts.Queries.Movies;
using GM.Sql.Entities;
using GM.Sql.Factories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GM.QueryHandlers.Movies;

public class MovieQueryHandler(IContextFactory contextFactory) : QueryHandlerBase, IQueryHandler<MovieQuery, MovieQueryResponse>
{
    private readonly IContextFactory contextFactory = contextFactory;

    public async Task<MovieQueryResponse> ExecuteAsync(MovieQuery query, CancellationToken cancellation)
    {
        await using var context = this.contextFactory.CreateContext();
        var movie = await context.Set<Movie>()
            .Where(x => x.Id == query.Id)
            .FirstOrDefaultAsync(cancellation);

        return movie != null ? new MovieQueryResponse
        {
            Movie = new MovieModel
            {
                Id = movie.Id,
                Description = movie.Description,
                ImageUrl = movie.ImageUrl,
                ReleaseYear = movie.ReleaseYear,
                SourceUrl = movie.SourceUrl,
                Title = movie.Title
            }
        } : new MovieQueryResponse { Movie = null };
    }
}
