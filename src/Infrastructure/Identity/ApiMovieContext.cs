using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity;

public partial class ApiMovieContext : DbContext
{
    public ApiMovieContext()
    {
    }

    public ApiMovieContext(DbContextOptions<ApiMovieContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioCredenciale> UsuarioCredenciales { get; set; }

    public virtual DbSet<UsuarioRole> UsuarioRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=ApiMovie;Username=core;Password=index;Pooling=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("actors_pkey");

            entity.ToTable("actors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comments_pkey");

            entity.ToTable("comments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.Text)
                .IsRequired()
                .HasColumnName("text");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Movie).WithMany(p => p.Comments)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comments_movie_id_fkey");
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("directors_pkey");

            entity.ToTable("directors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movies_pkey");

            entity.ToTable("movies");

            entity.HasIndex(e => e.MovieCode, "movies_movie_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Genre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("genre");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.MovieCode)
                .HasMaxLength(10)
                .HasColumnName("movie_code");
            entity.Property(e => e.Synopsis).HasColumnName("synopsis");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasMany(d => d.Actors).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MoviesActor",
                    r => r.HasOne<Actor>().WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("movies_actors_actor_id_fkey"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("movies_actors_movie_id_fkey"),
                    j =>
                    {
                        j.HasKey("MovieId", "ActorId").HasName("movies_actors_pkey");
                        j.ToTable("movies_actors");
                        j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");
                        j.IndexerProperty<int>("ActorId").HasColumnName("actor_id");
                    });

            entity.HasMany(d => d.Directors).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MoviesDirector",
                    r => r.HasOne<Director>().WithMany()
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("movies_directors_director_id_fkey"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("movies_directors_movie_id_fkey"),
                    j =>
                    {
                        j.HasKey("MovieId", "DirectorId").HasName("movies_directors_pkey");
                        j.ToTable("movies_directors");
                        j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");
                        j.IndexerProperty<int>("DirectorId").HasColumnName("director_id");
                    });
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ratings_pkey");

            entity.ToTable("ratings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.Rating1).HasColumnName("rating");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Movie).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ratings_movie_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ratings_usuario_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.InverseIdNavigation)
                .HasForeignKey<Role>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("roles_id_fkey");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_pkey");

            entity.ToTable("usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.InverseIdNavigation)
                .HasForeignKey<Usuario>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuario_id_fkey");
        });

        modelBuilder.Entity<UsuarioCredenciale>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("pk_usuario_credenciales");

            entity.ToTable("usuario_credenciales");

            entity.Property(e => e.UsuarioId)
                .ValueGeneratedNever()
                .HasColumnName("usuario_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.LastLogin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_login");
            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("password_hash");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Usuario).WithOne(p => p.UsuarioCredenciale)
                .HasForeignKey<UsuarioCredenciale>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuario_credenciales_usuario_id_fkey");
        });

        modelBuilder.Entity<UsuarioRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("usuario_roles");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Role).WithMany()
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuario_roles_role_id_fkey");

            entity.HasOne(d => d.Usuario).WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuario_roles_usuario_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
