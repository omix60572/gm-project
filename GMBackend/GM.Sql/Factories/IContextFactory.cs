using Microsoft.EntityFrameworkCore;

namespace GM.Sql.Factories;

public interface IContextFactory
{
    DbContext CreateContext();
}
