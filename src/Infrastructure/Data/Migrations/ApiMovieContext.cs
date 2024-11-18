using System.Reflection;
using Domain.Entities;

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


        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Usuarios { get; set; }

        public DbSet<UsuarioCredenciale> UsuarioCredenciales { get; set; }

        public DbSet<UsuarioRole> UsuarioRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            OnModelCreatingPartial(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
