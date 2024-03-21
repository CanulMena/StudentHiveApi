using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHiveApi.Infrastructure.Data.Configurations;

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable("Requests");
        builder.HasKey(e => e.IdRequest).HasName("PK__Requests__D5509880A1BE4613");
            builder.HasKey(e => e.IdRequest).HasName("PK__Requests__D550988064070693");

            builder.Property(e => e.IdRequest).HasColumnName("ID_Request");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.IdEvent).HasColumnName("ID_Event");
            builder.Property(e => e.IdPublication).HasColumnName("ID_Publication");
            builder.Property(e => e.IdUser).HasColumnName("ID_User");
            builder.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.IdEventNavigation).WithMany(p => p.Request)
                .HasForeignKey(d => d.IdEvent)
                .HasConstraintName("FK__Requests__ID_Eve__6383C8BA");

            builder.HasOne(d => d.IdPublicationNavigation).WithMany(p => p.Request)
                .HasForeignKey(d => d.IdPublication)
                .HasConstraintName("FK__Requests__ID_Pub__628FA481");

            builder.HasOne(d => d.IdUserNavigation).WithMany(p => p.Request)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Requests__ID_Use__619B8048");
    }
}