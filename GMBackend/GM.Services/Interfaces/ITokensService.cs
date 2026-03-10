using GM.Contracts.Models;

namespace GM.Services.Interfaces;

public interface ITokensService
{
    string CreateToken(UserModel user);
    bool ValidateToken(string token);
    uint GetExpireHours();
    DateTime GetExpireDateTime(string tokenString);
}
