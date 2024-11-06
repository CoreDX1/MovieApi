using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Migrations
{
    public partial class ApiMovieContext : DbContext
    {
        public ApiMovieContext(DbContextOptions<ApiMovieContext> options)
            : base(options) { }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            =>
            optionsBuilder.UseNpgsql(
                "Host=localhost;Database=ApiMovie;Username=core;Password=index;Pooling=true"
            );

        protected override void OnModelCreating(ModelBuilder builder)
        {
            OnModelCreatingPartial(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
