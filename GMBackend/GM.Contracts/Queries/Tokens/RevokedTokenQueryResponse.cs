namespace GM.Contracts.Queries.Tokens;

public class RevokedTokenQueryResponse : IQueryResponse
{
    public string ApplicationName { get; set; }
    public string Token { get; set; }
    public DateTime Expire { get; set; }
}
