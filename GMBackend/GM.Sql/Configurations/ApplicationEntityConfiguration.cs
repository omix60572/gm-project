using GM.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GM.Sql.Configurations;

public class ApplicationEntityConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable("Applications")
            .HasKey(x => x.ApplicationName);

        builder.Property(p => p.ApplicationName)
            .IsRequired()
            .HasMaxLength(80);
    }
}
