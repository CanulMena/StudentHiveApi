using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHiveApi.Infrastructure.Data.Configurations;

public class ReservationConfirmedConfiguration : IEntityTypeConfiguration<ReservationConfirmed>
{
    public void Configure(EntityTypeBuilder<ReservationConfirmed> builder)
    {
        builder.ToTable("ReservationsConfirmed");
        builder.HasKey(e => e.IdRerservation).HasName("PK__Reservat__FD6D9791105CF68A");

            builder.Property(e => e.IdRerservation).HasColumnName("ID_Rerservation");
            builder.Property(e => e.IdRequest).HasColumnName("ID_Request");
            builder.Property(e => e.RerservationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            builder.HasOne(d => d.IdRequestNavigation).WithMany(p => p.ReservationsConfirmed)
                .HasForeignKey(d => d.IdRequest)
                .HasConstraintName("FK__Reservati__ID_Re__07C12930");
        
    }
}