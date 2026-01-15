using GM.CommandHandlers.Tokens;
using GM.Contracts.Commands;
using GM.Contracts.Commands.Tokens;
using Microsoft.Extensions.DependencyInjection;

namespace GM.CommandHandlers;

public static class DIInjections
{
    public static IServiceCollection AddCommandHandlers(this IServiceCollection services) =>
        services
            // Movies
            // Tokens
            .AddTransient<ICommandHandler<SaveApplicationTokenCommand>, SaveApplicationTokenCommandHandler>()
            // Dispatcher
            .AddTransient<ICommandDispatcher, CommandDispatcher>();
}
