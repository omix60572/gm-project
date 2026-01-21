namespace GM.Contracts.Queries.Tokens;

public class RevokedTokenQuery : IQuery
{
    public string ApplicationName { get; set; }
    public string Token { get; set; }
}
