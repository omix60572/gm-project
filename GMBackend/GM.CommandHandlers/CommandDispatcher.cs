using GM.Contracts.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace GM.CommandHandlers;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider) =>
        this.serviceProvider = serviceProvider;

    public async Task ExecuteAsync<TCommand>(TCommand command, CancellationToken cancellation) where TCommand : ICommand
    {
        await using var handler = this.serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        await handler.ExecuteAsync(command, cancellation);
    }
}
