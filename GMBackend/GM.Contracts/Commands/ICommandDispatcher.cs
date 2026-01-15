namespace GM.Contracts.Commands;

public interface ICommandDispatcher
{
    Task ExecuteAsync<TCommand>(TCommand command, CancellationToken cancellation) where TCommand : ICommand;
}
