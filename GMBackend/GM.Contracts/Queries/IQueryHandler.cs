namespace GM.Contracts.Queries;

public interface IQueryHandler<in TQuery, TResponse> : IAsyncDisposable where TQuery : IQuery, new() where TResponse : IQueryResponse
{
    Task<TResponse> ExecuteAsync(TQuery query, CancellationToken cancellation);
}
