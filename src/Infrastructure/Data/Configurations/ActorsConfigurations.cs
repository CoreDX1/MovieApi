using Domain.Entities;

namespace Infrastructure.Data.Configurations;

public class ActorsConfigurations : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
            builder.HasKey(e => e.Id).HasName("actors_pkey");

            builder.ToTable("actors");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Birthdate).HasColumnName("birthdate");
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("first_name");
            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("last_name");
    }
}
