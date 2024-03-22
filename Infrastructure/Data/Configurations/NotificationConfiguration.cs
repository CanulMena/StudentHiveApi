using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHiveApi.Infrastructure.Data.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notifications");
            builder.HasKey(e => e.IdNotification).HasName("PK__Notifica__09D4F166A47B5735");

            builder.Property(e => e.IdNotification).HasColumnName("ID_Notification");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.IdEvent).HasColumnName("ID_Event");
            builder.Property(e => e.IdUser).HasColumnName("ID_User");
            builder.Property(e => e.Message).IsUnicode(false);

            builder.HasOne(d => d.IdEventNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.IdEvent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__ID_Ev__6A30C649");

            builder.HasOne(d => d.IdUserNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__ID_Us__6B24EA82");
    }
}