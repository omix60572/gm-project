using GM.Contracts.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace GM.QueryHandlers;

public class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public async Task<TResponse> ExecuteAsync<TQuery, TResponse>(TQuery query, CancellationToken cancellation)
        where TQuery : IQuery, new()
        where TResponse : IQueryResponse
    {
        await using var handler = this.serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResponse>>();
        return await handler.ExecuteAsync(query, cancellation);
    }
}
