using GM.Contracts.Queries;
using GM.Contracts.Queries.Movies;
using GM.QueryHandlers.Movies;
using Microsoft.Extensions.DependencyInjection;

namespace GM.QueryHandlers.Injections;

public static class DIInjectionsMovies
{
    public static IServiceCollection AddMoviesQueryHandlers(this IServiceCollection services)
    {
        services.AddTransient<IQueryHandler<PopularMoviesQuery, MoviesQueryResponse>, PopularMoviesQueryHandlerStub>();
        services.AddTransient<IQueryHandler<MoviesSearchQuery, MoviesQueryResponse>, MoviesSearchQueryHandlerStub>();
        return services;
    }
}
