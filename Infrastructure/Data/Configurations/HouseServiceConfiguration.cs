using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHiveApi.Infrastructure.Data.Configurations;

public class HouseServiceConfiguration : IEntityTypeConfiguration<HouseService>
{
    public void Configure(EntityTypeBuilder<HouseService> builder)
    {
        builder.ToTable("HouseServices");
            builder.HasKey(e => e.IdHouseService).HasName("PK__HouseSer__BBD08A23BAFA7918");

            builder.Property(e => e.IdHouseService).HasColumnName("ID_HouseService");
    }
}