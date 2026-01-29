using GM.Services.Interfaces;
using GM.Sql.Factories.Interfaces;
using GM.WebApi.Facades.Interfaces;

namespace GM.WebApi.Facades;

public class TokensFacade : ITokensFacade
{
    private readonly ITokenService tokenService;
    private readonly IContextFactory contextFactory;

    public TokensFacade(ITokenService tokenService, IContextFactory contextFactory)
    {
        this.tokenService = tokenService;
        this.contextFactory = contextFactory;
    }

    public string GetApplicationToken(string applicationName) =>
        this.tokenService.CreateToken(applicationName);

    public Task<bool> IsValidApplicationNameAsync(string applicationName, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public bool ValidateToken(string tokenString) =>
        this.tokenService.ValidateToken(tokenString);
}
