using GM.Contracts.Queries;
using GM.Contracts.Queries.Application;
using GM.Sql.Factories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ApplicationEntity = GM.Sql.Entities.Application;

namespace GM.QueryHandlers.Application;

public class ApplicationQueryHandler : QueryHandlerBase, IQueryHandler<ApplicationQuery, ApplicationQueryResponse>
{
    private readonly IContextFactory contextFactory;

    public ApplicationQueryHandler(IContextFactory contextFactory) =>
        this.contextFactory = contextFactory;

    public async Task<ApplicationQueryResponse> ExecuteAsync(ApplicationQuery query, CancellationToken cancellation)
    {
        await using var context = this.contextFactory.CreateContext();
        var application = await context.Set<ApplicationEntity>()
            .FirstOrDefaultAsync(x => x.ApplicationName == query.ApplicationName, cancellation);

        return application != null ? new ApplicationQueryResponse
        {
            ApplicationName = application.ApplicationName
        } : null;
    }
}
