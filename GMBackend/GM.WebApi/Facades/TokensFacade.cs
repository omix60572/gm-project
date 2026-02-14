using GM.Contracts.Commands;
using GM.Contracts.Commands.Tokens;
using GM.Contracts.Queries;
using GM.Contracts.Queries.Application;
using GM.Contracts.Queries.Tokens;
using GM.Services.Interfaces;
using GM.WebApi.Facades.Interfaces;
using GM.WebApi.Responses;
using NLog;

namespace GM.WebApi.Facades;

public class TokensFacade : ITokensFacade
{
    private readonly ITokensService tokensService;
    private readonly IQueryDispatcher queryDispatcher;
    private readonly ICommandDispatcher commandDispatcher;

    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    public TokensFacade(ITokensService tokensService, IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
    {
        this.tokensService = tokensService;
        this.queryDispatcher = queryDispatcher;
        this.commandDispatcher = commandDispatcher;
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
        var application = await this.queryDispatcher.ExecuteAsync<ApplicationQuery, ApplicationQueryResponse>(
            new ApplicationQuery { ApplicationName = applicationName },
            cancellation);

        return application != null;
    }

    public async Task<bool> RevokeTokenAsync(string applicationName, string tokenString, CancellationToken cancellation)
    {
        var existingRevokedToken = await this.queryDispatcher.ExecuteAsync<RevokedTokenQuery, RevokedTokenQueryResponse>(
            new RevokedTokenQuery { ApplicationName = applicationName, Token = tokenString },
            cancellation);
        
        if (existingRevokedToken != null)
            return true;

        try
        {
            var revokedTokenCommand = new SaveRevokedTokenCommand
            {
                ApplicationName = applicationName,
                Token = tokenString,
                Expire = this.tokensService.GetExpireDateTime(tokenString)
            };

            await this.commandDispatcher.ExecuteAsync(revokedTokenCommand, cancellation);
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
        var revokedToken = await this.queryDispatcher.ExecuteAsync<RevokedTokenQuery, RevokedTokenQueryResponse>(
            new RevokedTokenQuery { ApplicationName = applicationName, Token = tokenString },
            cancellation);

        if (revokedToken != null)
            return false;

        return this.tokensService.ValidateToken(tokenString);
    }
}
