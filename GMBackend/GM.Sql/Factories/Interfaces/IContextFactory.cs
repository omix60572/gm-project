using Microsoft.EntityFrameworkCore;

namespace GM.Sql.Factories.Interfaces;

public interface IContextFactory
{
    DbContext CreateContext();
}
