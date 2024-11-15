using Domain.Entities;

namespace Infrastructure.Data.Configurations;

public class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(e => e.Id).HasName("roles_pkey");

        builder.ToTable("roles");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("name");

        builder
            .HasOne(d => d.IdNavigation)
            .WithOne(p => p.InverseIdNavigation)
            .HasForeignKey<Role>(d => d.Id)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("roles_id_fkey");
    }
}
