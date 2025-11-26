using GM.Contracts.Queries;
using GM.QueryHandlers.Injections;
using Microsoft.Extensions.DependencyInjection;

namespace GM.QueryHandlers;

public static class DIInjections
{
    public static IServiceCollection AddQueryHandlers(this IServiceCollection services) =>
        services
            .AddMoviesQueryHandlers()
            .AddTransient<IQueryDispatcher, QueryDispatcher>();
}
