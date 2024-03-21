using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHiveApi.Infrastructure.Data.Configurations;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.ToTable("Reports");
            builder.HasKey(e => e.IdReport).HasName("PK__Reports__C6245294B037B149");
            builder.Property(e => e.IdReport).HasColumnName("ID_Report");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.IdPublication).HasColumnName("ID_Publication");
            builder.Property(e => e.IdReportType).HasColumnName("ID_ReportType");
            builder.Property(e => e.IdUser).HasColumnName("ID_User");

            builder.HasOne(d => d.IdPublication1).WithMany(p => p.Report)
                .HasForeignKey(d => d.IdPublication)
                .HasConstraintName("FK__Reports__ID_Publ__5165187F");

            builder.HasOne(d => d.IdReportTypeNavigation).WithMany(p => p.Report)
                .HasForeignKey(d => d.IdReportType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reports__ID_Repo__52593CB8");

            builder.HasOne(d => d.IdUserNavigation).WithMany(p => p.Report)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Reports__ID_User__5070F446");

            builder.HasMany(d => d.IdPublicationNavigation).WithMany(p => p.IdReport)
                .UsingEntity<Dictionary<string, object>>(
                    "PublicationReports",
                    r => r.HasOne<RentalHouse>().WithMany()
                        .HasForeignKey("IdPublication")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Publicati__ID_Pu__5629CD9C"),
                    l => l.HasOne<Report>().WithMany()
                        .HasForeignKey("IdReport")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Publicati__ID_Re__5535A963"),
                    j =>
                    {
                        j.HasKey("IdReport", "IdPublication").HasName("PK__Publicat__6B6B333719E3344B");
                        j.IndexerProperty<int>("IdReport").HasColumnName("ID_Report");
                        j.IndexerProperty<int>("IdPublication").HasColumnName("ID_Publication");
                    });
    }
}