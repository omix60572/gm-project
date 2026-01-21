using GM.Contracts.Commands;
using GM.Contracts.Commands.Tokens;
using GM.Sql.Entities;
using GM.Sql.Factories.Interfaces;
using NLog;

namespace GM.CommandHandlers.Tokens;

public class SaveRevokedTokenCommandHandler : CommandHandlerBase, ICommandHandler<SaveRevokedTokenCommand>
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();
    private readonly IContextFactory contextFactory;

    public SaveRevokedTokenCommandHandler(IContextFactory contextFactory) =>
        this.contextFactory = contextFactory;

    public async Task ExecuteAsync(SaveRevokedTokenCommand command, CancellationToken cancellation)
    {
        try
        {
            await using var context = this.contextFactory.CreateContext();

            var revokedToken = new RevokedToken
            {
                ApplicationName = command.ApplicationName,
                Expire = command.Expire,
                Token = command.Token
            };
            context.Set<RevokedToken>().Add(revokedToken);

            await context.SaveChangesAsync(cancellation);
        }
        catch (Exception ex)
        {
            // TODO: Fix logging message
            this.logger.Error(ex);
        }
    }
}
