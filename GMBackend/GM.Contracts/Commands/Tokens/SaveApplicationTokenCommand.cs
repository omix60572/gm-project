namespace GM.Contracts.Commands.Tokens;

public class SaveApplicationTokenCommand : ICommand
{
    public string ApplicationName { get; set; }
    public DateTime Expire {  get; set; }
}
