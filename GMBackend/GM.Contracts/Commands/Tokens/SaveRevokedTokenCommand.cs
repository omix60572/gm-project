namespace GM.Contracts.Commands.Tokens;

public class SaveRevokedTokenCommand : ICommand
{
    public string ApplicationName { get; set; }
    public DateTime Expire {  get; set; }
    public string Token { get; set; }
}
