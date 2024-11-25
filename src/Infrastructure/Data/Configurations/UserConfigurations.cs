using Domain.Entities;

namespace Infrastructure.Data.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(e => e.Id).HasName("usuario_pkey");

        builder.ToTable("usuario");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Email).IsRequired().HasMaxLength(50).HasColumnName("email");
        builder.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("name");

        builder
            .HasOne(d => d.IdNavigation)
            .WithOne(p => p.InverseIdNavigation)
            .HasForeignKey<Usuario>(d => d.Id)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("usuario_id_fkey");
    }
}
