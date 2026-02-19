using GM.Contracts.Models;

namespace GM.Contracts.Commands.Movies;

public class AddNewMovieCommand : ICommand
{
    public MovieModel movie { get; set; }
}
