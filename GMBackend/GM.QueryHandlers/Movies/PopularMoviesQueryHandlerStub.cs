using GM.Contracts.Models;
using GM.Contracts.Queries;
using GM.Contracts.Queries.Movies;
using GM.Sql.Entities;
using GM.Sql.Factories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GM.QueryHandlers.Movies;

// TODO: Replace stub implementation
public class PopularMoviesQueryHandlerStub(IContextFactory contextFactory) : QueryHandlerBase, IQueryHandler<PopularMoviesQuery, MoviesQueryResponse>
{
    private readonly IContextFactory contextFactory = contextFactory;

    public async Task<MoviesQueryResponse> ExecuteAsync(PopularMoviesQuery query, CancellationToken cancellation)
    {
        await using var context = this.contextFactory.CreateContext();
        var movies = await context.Set<Movie>()
            .Take(100)
            .Select(x => new MovieModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                ReleaseYear = x.ReleaseYear,
                SourceUrl = x.SourceUrl
            })
            .ToListAsync(cancellation);

        return new MoviesQueryResponse { Movies = movies };
    }
}
