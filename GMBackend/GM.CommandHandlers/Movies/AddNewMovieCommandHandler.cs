using GM.Contracts.Commands;
using GM.Contracts.Commands.Movies;
using GM.Sql.Entities;
using GM.Sql.Factories.Interfaces;
using NLog;

namespace GM.CommandHandlers.Movies;

public class AddNewMovieCommandHandler : CommandHandlerBase, ICommandHandler<AddNewMovieCommand>
{
    private readonly IContextFactory contextFactory;
    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    public AddNewMovieCommandHandler(IContextFactory contextFactory) =>
        this.contextFactory = contextFactory;

    public async Task ExecuteAsync(AddNewMovieCommand command, CancellationToken cancellation)
    {
        try
        {
            var movie = new Movie
            {
                Title = command.movie.Title,
                Description = command.movie.Description,
                ImageUrl = command.movie.ImageUrl,
                ReleaseYear = command.movie.ReleaseYear,
                SourceUrl = command.movie.SourceUrl
            };

            await using var context = this.contextFactory.CreateContext();
            await context.Set<Movie>().AddAsync(movie, cancellation);
            await context.SaveChangesAsync(cancellation);
        }
        catch (Exception ex)
        {
            this.logger.Error(ex, "Failed to add new movie to database");
        }
    }
}
