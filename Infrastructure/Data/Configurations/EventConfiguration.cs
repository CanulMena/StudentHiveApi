using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHiveApi.Infrastructure.Data.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");
            builder.HasKey(e => e.IdEvent).HasName("PK__Events__12A4DF3F58D6D62B");

            builder.Property(e => e.IdEvent).HasColumnName("ID_Event");
            builder.Property(e => e.EventType)
                .HasMaxLength(50)
                .IsUnicode(false);
    }
}