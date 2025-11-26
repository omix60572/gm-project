namespace GM.QueryHandlers;

public class QueryHandlerBase : IAsyncDisposable
{
    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }
}
