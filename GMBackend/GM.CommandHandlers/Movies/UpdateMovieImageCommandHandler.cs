using GM.Contracts.Commands;
using GM.Contracts.Commands.Movies;

namespace GM.CommandHandlers.Movies;

public class UpdateMovieImageCommandHandler : CommandHandlerBase, ICommandHandler<UpdateMovieImageCommand>
{
    public Task ExecuteAsync(UpdateMovieImageCommand command, CancellationToken cancellation)
    {
        return Task.CompletedTask;
    }
}
