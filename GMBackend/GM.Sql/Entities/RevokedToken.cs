namespace GM.Sql.Entities;

public class RevokedToken
{
    public long Id { get; set; }
    public string ApplicationName { get; set; }
    public DateTime Expire { get; set; }
    public string Token { get; set; }
}
