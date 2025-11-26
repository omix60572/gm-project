using GM.Contracts.Models;
using System.Collections.Generic;

namespace GM.WebApi.Responses;

public class MoviesResponse
{
    public IEnumerable<MovieModel> Movies { get; set; }
}
