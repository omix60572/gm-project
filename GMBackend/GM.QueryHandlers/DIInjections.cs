using GM.Contracts.Queries;
using GM.Contracts.Queries.Application;
using GM.Contracts.Queries.Movies;
using GM.Contracts.Queries.Tokens;
using GM.QueryHandlers.Application;
using GM.QueryHandlers.Movies;
using GM.QueryHandlers.Tokens;
using Microsoft.Extensions.DependencyInjection;

namespace GM.QueryHandlers;

public static class DIInjections
{
    public static IServiceCollection AddQueryHandlers(this IServiceCollection services) =>
        services
            // Application
            .AddTransient<IQueryHandler<ApplicationQuery, ApplicationQueryResponse>, ApplicationQueryHandler>()
            // Movies
            .AddTransient<IQueryHandler<PopularMoviesQuery, MoviesQueryResponse>, PopularMoviesQueryHandlerStub>()
            .AddTransient<IQueryHandler<MoviesSearchQuery, MoviesQueryResponse>, MoviesSearchQueryHandlerStub>()
            .AddTransient<IQueryHandler<MovieQuery, MovieQueryResponse>, MovieQueryHandler>()
            // Tokens
            .AddTransient<IQueryHandler<RevokedTokenQuery, RevokedTokenQueryResponse>, RevokedTokenQueryHandler>()
            // Dispatcher
            .AddTransient<IQueryDispatcher, QueryDispatcher>();
}
