using Domain.Entities;

namespace Infrastructure.Data.Configurations;

public class UserRolConfiguration : IEntityTypeConfiguration<UsuarioRole>
{
    public void Configure(EntityTypeBuilder<UsuarioRole> builder)
    {
        builder.HasNoKey().ToTable("usuario_roles");

        builder
            .Property(e => e.CreatedAt)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created_at");
        builder.Property(e => e.RoleId).HasColumnName("role_id");
        builder
            .Property(e => e.UpdatedAt)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("updated_at");
        builder.Property(e => e.UsuarioId).HasColumnName("usuario_id");

        builder
            .HasOne(d => d.Role)
            .WithMany()
            .HasForeignKey(d => d.RoleId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("usuario_roles_role_id_fkey");

        builder
            .HasOne(d => d.Usuario)
            .WithMany()
            .HasForeignKey(d => d.UsuarioId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("usuario_roles_usuario_id_fkey");
    }
}
