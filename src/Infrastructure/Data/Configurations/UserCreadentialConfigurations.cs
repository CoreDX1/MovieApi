using Domain.Entities;

namespace Infrastructure.Data.Configurations;

public class UserCredentialConfigurations : IEntityTypeConfiguration<UsuarioCredenciale>
{
    public void Configure(EntityTypeBuilder<UsuarioCredenciale> builder)
    {

        builder.HasNoKey().ToTable("usuario_credenciales");

        builder.HasKey(e => e.UsuarioId);

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
            .HasMaxLength(50)
            .HasColumnName("password_hash");
        builder
            .Property(e => e.UpdatedAt)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("updated_at");
        builder.Property(e => e.UsuarioId).HasColumnName("usuario_id");

        builder
            .HasOne(d => d.Usuario)
            .WithMany()
            .HasForeignKey(d => d.UsuarioId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("usuario_credenciales_usuario_id_fkey");
    }
}
