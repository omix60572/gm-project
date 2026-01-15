namespace GM.CommandHandlers;

public class CommandHandlerBase : IAsyncDisposable
{
    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }
}
