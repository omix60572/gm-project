using GM.Contracts.Queries;
using GM.Contracts.Queries.Movies;
using GM.QueryHandlers.Movies;
using Microsoft.Extensions.DependencyInjection;

namespace GM.QueryHandlers;

public static class DIInjections
{
    public static IServiceCollection AddQueryHandlers(this IServiceCollection services) =>
        services
            // Movies
            .AddTransient<IQueryHandler<PopularMoviesQuery, MoviesQueryResponse>, PopularMoviesQueryHandlerStub>()
            .AddTransient<IQueryHandler<MoviesSearchQuery, MoviesQueryResponse>, MoviesSearchQueryHandlerStub>()
            .AddTransient<IQueryHandler<MovieQuery, MovieQueryResponse>, MovieQueryHandler>()
            // Tokens
            // Dispatcher
            .AddTransient<IQueryDispatcher, QueryDispatcher>();
}
