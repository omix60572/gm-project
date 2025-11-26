namespace GM.Contracts.Queries;

public interface IQueryDispatcher
{
    Task<TResponse> ExecuteAsync<TQuery, TResponse>(TQuery query, CancellationToken cancellation) where TQuery : IQuery, new() where TResponse : IQueryResponse;
}
