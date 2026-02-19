using GM.CommandHandlers.Movies;
using GM.CommandHandlers.Tokens;
using GM.Contracts.Commands;
using GM.Contracts.Commands.Movies;
using GM.Contracts.Commands.Tokens;
using Microsoft.Extensions.DependencyInjection;

namespace GM.CommandHandlers;

public static class DIInjections
{
    public static IServiceCollection AddCommandHandlers(this IServiceCollection services) =>
        services
            // Movies
            .AddTransient<ICommandHandler<AddNewMovieCommand>, AddNewMovieCommandHandler>()
            .AddTransient<ICommandHandler<UpdateMovieImageCommand>, UpdateMovieImageCommandHandler>()
            // Tokens
            .AddTransient<ICommandHandler<SaveRevokedTokenCommand>, SaveRevokedTokenCommandHandler>()
            // Dispatcher
            .AddTransient<ICommandDispatcher, CommandDispatcher>();
}
