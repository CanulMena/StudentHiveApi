using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHiveApi.Infrastructure.Data.Configurations;

public class RentalHouseDetailConfiguration : IEntityTypeConfiguration<RentalHouseDetail>
{
    public void Configure(EntityTypeBuilder<RentalHouseDetail> builder)
    {
        builder.ToTable("RentalHouseDetails");
        builder.HasKey(e => e.IdRentalHouseDetail).HasName("PK__RentalHo__EDFA085EE889F0BB");

            builder.Property(e => e.IdRentalHouseDetail).HasColumnName("ID_RentalHouseDetail");
    }
}