using GM.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GM.Sql.Configurations;

public class MovieEntityConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies")
            .HasKey(x => x.Id);

        builder.Property(p => p.ImageUrl)
            .HasMaxLength(255);

        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.ReleaseYear)
            .IsRequired();

        builder.Property(p => p.SourceUrl)
            .HasMaxLength(255);
    }
}
