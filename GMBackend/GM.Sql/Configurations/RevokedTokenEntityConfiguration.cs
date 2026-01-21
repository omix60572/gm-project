using GM.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GM.Sql.Configurations;

public class RevokedTokenEntityConfiguration : IEntityTypeConfiguration<RevokedToken>
{
    public void Configure(EntityTypeBuilder<RevokedToken> builder)
    {
        builder.ToTable("RevokedTokens")
            .HasKey(x => x.Id);

        builder.Property(p => p.ApplicationName)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(p => p.Expire)
            .IsRequired();

        builder.Property(p => p.Token)
            .IsRequired();
    }
}
