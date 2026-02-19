using GM.Sql.Factories;
using GM.Sql.Factories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GM.Sql;

public static class DIInjections
{
    public static IServiceCollection AddSql(this IServiceCollection services, SqlSettings sqlSettings) =>
        services
            .AddSingleton(sqlSettings)
            .AddTransient<IContextFactory, ContextFactory>();

    public static IServiceCollection ConfigureSqlSettings(this IServiceCollection services, IConfiguration configuration) =>
        services.Configure<SqlSettings>(configuration.GetSection(SqlSettings.Section));
}
