using Domain.Entities;
namespace Infrastructure.Data.Configurations;

public class CommentConfigurations : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {

            builder.HasKey(e => e.Id).HasName("comments_pkey");

            builder.ToTable("comments");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Date).HasColumnName("date");
            builder.Property(e => e.MovieId).HasColumnName("movie_id");
            builder.Property(e => e.Text)
                .IsRequired()
                .HasColumnName("text");
            builder.Property(e => e.UsuarioId).HasColumnName("usuario_id");
    }
}
