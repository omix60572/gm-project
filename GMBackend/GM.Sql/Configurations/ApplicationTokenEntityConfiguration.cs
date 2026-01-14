using GM.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GM.Sql.Configurations;

public class ApplicationTokenEntityConfiguration : IEntityTypeConfiguration<ApplicationToken>
{
    public void Configure(EntityTypeBuilder<ApplicationToken> builder)
    {
        builder.ToTable("ApplicationTokens")
            .HasKey(x => x.ApplicationName);

        builder.Property(p => p.ApplicationName)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(p => p.Expire)
            .IsRequired();
    }
}
