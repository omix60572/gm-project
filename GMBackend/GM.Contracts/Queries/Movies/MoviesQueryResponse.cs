using GM.Contracts.Models;

namespace GM.Contracts.Queries.Movies;

public class MoviesQueryResponse : IQueryResponse
{
    public IEnumerable<MovieModel> Movies { get; set; }
}
