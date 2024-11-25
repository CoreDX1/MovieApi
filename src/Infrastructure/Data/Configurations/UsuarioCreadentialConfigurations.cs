using Domain.Entities;

namespace Infrastructure.Data.Configurations;

public class UsuarioCredentialConfigurations : IEntityTypeConfiguration<UsuarioCredenciale>
{
    public void Configure(EntityTypeBuilder<UsuarioCredenciale> builder)
    {
        builder.HasKey(e => e.UsuarioId).HasName("pk_usuario_credenciales");

        builder.ToTable("usuario_credenciales");

        builder.Property(e => e.UsuarioId).ValueGeneratedNever().HasColumnName("usuario_id");
        builder
            .Property(e => e.CreatedAt)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created_at");
        builder
            .Property(e => e.LastLogin)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("last_login");
        builder
            .Property(e => e.PasswordHash)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("password_hash");
        builder
            .Property(e => e.UpdatedAt)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("updated_at");

        builder
            .HasOne(d => d.Usuario)
            .WithOne(p => p.UsuarioCredenciale)
            .HasForeignKey<UsuarioCredenciale>(d => d.UsuarioId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("usuario_credenciales_usuario_id_fkey");
    }
}
