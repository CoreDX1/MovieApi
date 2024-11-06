using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class MovieConfigurations : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(e => e.Id).HasName("movies_pkey");

        builder.ToTable("movies");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Duration).HasColumnName("duration");
        builder.Property(e => e.Genre).HasMaxLength(255).HasColumnName("genre");
        builder.Property(e => e.Image).HasMaxLength(255).HasColumnName("image");
        builder.Property(e => e.Synopsis).HasColumnName("synopsis");
        builder.Property(e => e.Title).HasMaxLength(255).HasColumnName("title");
        builder.Property(e => e.Year).HasColumnName("year");

        builder
            .HasMany(d => d.Actors)
            .WithMany(p => p.Movies)
            .UsingEntity<Dictionary<string, object>>(
                "MoviesActor",
                r =>
                    r.HasOne<Actor>()
                        .WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("movies_actors_actor_id_fkey"),
                l =>
                    l.HasOne<Movie>()
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("movies_actors_movie_id_fkey"),
                j =>
                {
                    j.HasKey("MovieId", "ActorId").HasName("movies_actors_pkey");
                    j.ToTable("movies_actors");
                    j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");
                    j.IndexerProperty<int>("ActorId").HasColumnName("actor_id");
                }
            );

        builder
            .HasMany(d => d.Directors)
            .WithMany(p => p.Movies)
            .UsingEntity<Dictionary<string, object>>(
                "MoviesDirector",
                r =>
                    r.HasOne<Director>()
                        .WithMany()
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("movies_directors_director_id_fkey"),
                l =>
                    l.HasOne<Movie>()
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("movies_directors_movie_id_fkey"),
                j =>
                {
                    j.HasKey("MovieId", "DirectorId").HasName("movies_directors_pkey");
                    j.ToTable("movies_directors");
                    j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");
                    j.IndexerProperty<int>("DirectorId").HasColumnName("director_id");
                }
            );
    }
}
