using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHiveApi.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(e => e.IdUser).HasName("PK__Users__ED4DE44298421041");

            builder.Property(e => e.IdUser).HasColumnName("ID_User");
            builder.Property(e => e.Description).IsUnicode(false);
            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.IdRol).HasColumnName("ID_Rol");
            builder.Property(e => e.IdTypeReport).HasColumnName("ID_TypeReport");
            builder.Property(e => e.LastName).IsUnicode(false);
            builder.Property(e => e.Name).IsUnicode(false);
            builder.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.ProfilePhotoUrl).IsUnicode(false);
            builder.Property(e => e.UserAge).HasColumnName("User_Age");

            builder.HasOne(d => d.IdRolNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Users__ID_Rol__5165187F");

            builder.HasOne(d => d.IdTypeReportNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdTypeReport)
                .HasConstraintName("FK__Users__ID_TypeRe__5070F446");
    }
}