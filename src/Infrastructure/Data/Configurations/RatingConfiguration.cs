using Domain.Entities;

namespace Infrastructure.Data.Configurations;

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.HasKey(e => e.Id).HasName("ratings_pkey");

        builder.ToTable("ratings");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Date).HasColumnName("date");
        builder.Property(e => e.MovieId).HasColumnName("movie_id");
        builder.Property(e => e.Rating1).HasColumnName("rating");
        builder.Property(e => e.UsuarioId).HasColumnName("usuario_id");

        builder
            .HasOne(d => d.Movie)
            .WithMany(p => p.Ratings)
            .HasForeignKey(d => d.MovieId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ratings_movie_id_fkey");

        builder
            .HasOne(d => d.Usuario)
            .WithMany(p => p.Ratings)
            .HasForeignKey(d => d.UsuarioId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ratings_usuario_id_fkey");
    }
}
