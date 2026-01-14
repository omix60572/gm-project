namespace GM.Services.Interfaces;

public interface ITokenService
{
    string CreateToken(string applicationName);
    bool ValidateToken(string token);
}
