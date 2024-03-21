using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHiveApi.Infrastructure.Data.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations");
            builder.HasKey(e => e.IdLocation).HasName("PK__Location__2F2C70A78E7A59B5");

            builder.Property(e => e.IdLocation).HasColumnName("ID_Location");
            builder.Property(e => e.Address)
                .HasMaxLength(400)
                .IsUnicode(false);
            builder.Property(e => e.City)
                .HasMaxLength(400)
                .IsUnicode(false);
            builder.Property(e => e.Country)
                .HasMaxLength(400)
                .IsUnicode(false);
            builder.Property(e => e.Neighborhood)
                .HasMaxLength(400)
                .IsUnicode(false);
            builder.Property(e => e.State)
                .HasMaxLength(400)
                .IsUnicode(false);
    }
}