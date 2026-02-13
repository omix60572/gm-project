using GM.WebApi.Responses;

namespace GM.WebApi.Facades.Interfaces;

public interface ITokensFacade
{
    Task<bool> ValidateTokenAsync(string applicationName, string tokenString, CancellationToken cancellation);
    Task<bool> IsValidApplicationNameAsync(string applicationName, CancellationToken cancellation);
    ApplicationTokenResponse GetApplicationToken(string applicationName);
    Task<bool> RevokeTokenAsync(string applicationName, string tokenString, CancellationToken cancellation);
}
