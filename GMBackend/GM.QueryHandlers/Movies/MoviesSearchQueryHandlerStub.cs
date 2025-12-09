using GM.Contracts.Models;
using GM.Contracts.Queries;
using GM.Contracts.Queries.Movies;
using GM.Sql.Entities;
using GM.Sql.Factories;
using Microsoft.EntityFrameworkCore;

namespace GM.QueryHandlers.Movies;

// TODO: Replace stub implementation
public class MoviesSearchQueryHandlerStub(IContextFactory contextFactory) : QueryHandlerBase, IQueryHandler<MoviesSearchQuery, MoviesQueryResponse>
{
    private readonly IContextFactory contextFactory = contextFactory;

    public async Task<MoviesQueryResponse> ExecuteAsync(MoviesSearchQuery query, CancellationToken cancellation)
    {
        await using var context = this.contextFactory.CreateContext();
        var movies = await context.Set<Movie>()
            .Where(x => x.Title.Contains(query.SearchQuery, StringComparison.CurrentCultureIgnoreCase))
            .Take(100)
            .ToListAsync(cancellation);

        return new MoviesQueryResponse
        {
            Movies = movies.ConvertAll(x => new MovieModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                ReleaseYear = x.ReleaseYear,
                SourceUrl = x.SourceUrl
            })
        };
    }
}
