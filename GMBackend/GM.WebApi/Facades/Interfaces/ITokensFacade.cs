namespace GM.WebApi.Facades.Interfaces;

public interface ITokensFacade
{
    bool ValidateToken(string tokenString);
    Task<bool> IsValidApplicationNameAsync(string applicationName, CancellationToken cancellation);
    string GetApplicationToken(string applicationName);
}
