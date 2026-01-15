namespace GM.Contracts.Commands;

public interface ICommandHandler<in TCommand> : IAsyncDisposable where TCommand : ICommand
{
    Task ExecuteAsync(TCommand command, CancellationToken cancellation);
}
