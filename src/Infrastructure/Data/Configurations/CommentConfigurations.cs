using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        builder.Property(e => e.Text).HasColumnName("text");

        builder
            .HasOne(d => d.Movie)
            .WithMany(p => p.Comments)
            .HasForeignKey(d => d.MovieId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("comments_movie_id_fkey");
    }
}
