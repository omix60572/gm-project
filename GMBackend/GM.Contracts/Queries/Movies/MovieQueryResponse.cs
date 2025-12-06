using GM.Contracts.Models;

namespace GM.Contracts.Queries.Movies;

public class MovieQueryResponse : IQueryResponse
{
    public MovieModel Movie { get; set; }
}
