using GM.Contracts.Models;
using GM.Contracts.Queries;
using GM.Contracts.Queries.Movies;
using GM.Sql.Entities;
using GM.Sql.Factories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GM.QueryHandlers.Movies;

public class MoviesQueryHandler : QueryHandlerBase, IQueryHandler<MoviesQuery, MoviesQueryResponse>
{
    private readonly IContextFactory contextFactory;

    public MoviesQueryHandler(IContextFactory contextFactory) =>
        this.contextFactory = contextFactory;

    public async Task<MoviesQueryResponse> ExecuteAsync(MoviesQuery query, CancellationToken cancellation)
    {
        await using var context = this.contextFactory.CreateContext();
        var movies = await context.Set<Movie>()
            .Where(x => query.Ids.Contains(x.Id))
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
