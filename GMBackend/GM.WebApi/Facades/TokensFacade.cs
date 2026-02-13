using GM.Services.Interfaces;
using GM.Sql.Entities;
using GM.Sql.Factories.Interfaces;
using GM.WebApi.Facades.Interfaces;
using GM.WebApi.Responses;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace GM.WebApi.Facades;

public class TokensFacade : ITokensFacade
{
    private readonly ITokensService tokensService;
    private readonly IContextFactory contextFactory;

    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    public TokensFacade(ITokensService tokensService, IContextFactory contextFactory)
    {
        this.tokensService = tokensService;
        this.contextFactory = contextFactory;
    }

    public ApplicationTokenResponse GetApplicationToken(string applicationName)
    {
        return new ApplicationTokenResponse
        {
            ApplicationToken = this.tokensService.CreateToken(applicationName),
            ExpireHours = this.tokensService.GetExpireHours()
        };
    }

    public async Task<bool> IsValidApplicationNameAsync(string applicationName, CancellationToken cancellation)
    {
        await using var context = this.contextFactory.CreateContext();
        var application = await context
            .Set<Application>()
            .FirstOrDefaultAsync(x => x.ApplicationName == applicationName, cancellation);

        return application != null;
    }

    public async Task<bool> RevokeTokenAsync(string applicationName, string tokenString, CancellationToken cancellation)
    {
        await using var context = this.contextFactory.CreateContext();
        var existingRevokedToken = await context
            .Set<RevokedToken>()
            .Where(x => x.ApplicationName == applicationName)
            .FirstOrDefaultAsync(x => x.Token == tokenString, cancellation);
        if (existingRevokedToken != null)
            return true;

        try
        {
            var revokedToken = new RevokedToken
            {
                ApplicationName = applicationName,
                Token = tokenString
            };

            context.Add(revokedToken);
            await context.SaveChangesAsync(cancellation);

            return true;
        }
        catch (Exception ex)
        {
            this.logger.Error(ex, "Failed to save revoked token");
        }

        return false;
    }

    public async Task<bool> ValidateTokenAsync(string applicationName, string tokenString, CancellationToken cancellation)
    {
        await using var context = this.contextFactory.CreateContext();
        var revokedToken = await context
            .Set<RevokedToken>()
            .Where(x => x.ApplicationName == applicationName)
            .FirstOrDefaultAsync(x => x.Token == tokenString, cancellation);

        if (revokedToken != null)
            return false;

        return this.tokensService.ValidateToken(tokenString);
    }
}
