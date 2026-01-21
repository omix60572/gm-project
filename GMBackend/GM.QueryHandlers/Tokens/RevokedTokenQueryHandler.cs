using GM.Contracts.Queries;
using GM.Contracts.Queries.Tokens;
using GM.Sql.Entities;
using GM.Sql.Factories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GM.QueryHandlers.Tokens;

public class RevokedTokenQueryHandler : QueryHandlerBase, IQueryHandler<RevokedTokenQuery, RevokedTokenQueryResponse>
{
    private readonly IContextFactory contextFactory;

    public RevokedTokenQueryHandler(IContextFactory contextFactory) =>
        this.contextFactory = contextFactory;

    public async Task<RevokedTokenQueryResponse> ExecuteAsync(RevokedTokenQuery query, CancellationToken cancellation)
    {
        await using var context = this.contextFactory.CreateContext();
        var revokedToken = await context.Set<RevokedToken>()
            .Where(x => x.ApplicationName == query.ApplicationName)
            .FirstOrDefaultAsync(x => x.Token == query.Token, cancellation);

        return revokedToken != null ? new RevokedTokenQueryResponse
        {
            ApplicationName = revokedToken.ApplicationName,
            Token = revokedToken.Token,
            Expire = revokedToken.Expire
        } : null;
    }
}
