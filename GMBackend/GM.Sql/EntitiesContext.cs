using GM.Sql.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GM.Sql;

public class EntitiesContext : DbContext
{
    public EntitiesContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new MovieEntityConfiguration());
    }
}
