namespace GM.Services.Interfaces;

public interface ITokensService
{
    string CreateToken(string applicationName);
    bool ValidateToken(string token);
    uint GetExpireHours();
}
