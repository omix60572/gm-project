using GM.Sql.Enums;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace GM.Sql.Factories;

public class ContextFactory : IContextFactory
{
    private readonly DbContextOptions dbContextOptions;
    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    public ContextFactory(SqlSettings settings)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DbContext>();

        switch (settings.SqlProvider)
        {
            case SqlProviders.SQLite:
            {
                this.dbContextOptions = optionsBuilder
                    .UseSqlite(settings.ConnectionString)
                    .Options;

                break;
            }

            case SqlProviders.MSSQL:
            {
                this.dbContextOptions = optionsBuilder
                    .UseSqlServer(settings.ConnectionString)
                    .Options;

                break;
            }

            case SqlProviders.None:
            {
                this.logger.Fatal("Sql provider type is not set in appsettings.json");
                throw new NotImplementedException();
            }

            default:
                throw new NotImplementedException();
        }
    }

    public DbContext CreateContext() =>
        new EntitiesContext(this.dbContextOptions);
}
