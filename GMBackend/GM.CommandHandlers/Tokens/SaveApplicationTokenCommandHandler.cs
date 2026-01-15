using GM.Contracts.Commands;
using GM.Contracts.Commands.Tokens;
using GM.Sql.Factories;

namespace GM.CommandHandlers.Tokens;

public class SaveApplicationTokenCommandHandler : CommandHandlerBase, ICommandHandler<SaveApplicationTokenCommand>
{
    private readonly IContextFactory contextFactory;

    public SaveApplicationTokenCommandHandler(IContextFactory contextFactory) =>
        this.contextFactory = contextFactory;

    public Task ExecuteAsync(SaveApplicationTokenCommand command, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }
}
