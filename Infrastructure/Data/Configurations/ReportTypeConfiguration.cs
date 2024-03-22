using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHiveApi.Infrastructure.Data.Configurations;

public class ReportTypeConfiguration : IEntityTypeConfiguration<ReportType>
{
    public void Configure(EntityTypeBuilder<ReportType> builder)
    {
        builder.ToTable("ReportTypes");
            builder.HasKey(e => e.IdTypeReport).HasName("PK__ReportTy__BA174E563BF40B50");

            builder.Property(e => e.IdTypeReport).HasColumnName("ID_TypeReport");
            builder.Property(e => e.TypeReportName)
                .IsUnicode(false)
                .HasColumnName("Type_ReportName");

    }
}