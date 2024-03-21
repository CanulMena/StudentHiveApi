using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHiveApi.Infrastructure.Data.Configurations;

        public class EventSubscriptionsConfiguration : IEntityTypeConfiguration<EventSubscription>
        {
            public void Configure(EntityTypeBuilder<EventSubscription> builder)
            
            {
                builder.ToTable("EventSubscriptions");
                    builder.HasKey(e => e.IdSubscription).HasName("PK__EventSub__1305B0051F8153B6");

                    builder.Property(e => e.IdSubscription).HasColumnName("ID_Subscription");
                    builder.Property(e => e.IdEvent).HasColumnName("ID_Event");
                    builder.Property(e => e.IdUser).HasColumnName("ID_User");

                    builder.HasOne(d => d.IdEventNavigation).WithMany(p => p.EventSubscription)
                        .HasForeignKey(d => d.IdEvent)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventSubs__ID_Ev__5EBF139D");

                    builder.HasOne(d => d.IdUserNavigation).WithMany(p => p.EventSubscriptions)
                        .HasForeignKey(d => d.IdUser)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventSubs__ID_Us__5DCAEF64");

            }
        }
