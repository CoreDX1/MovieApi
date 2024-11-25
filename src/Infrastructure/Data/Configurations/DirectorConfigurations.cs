using Domain.Entities;

namespace Infrastructure.Data.Configurations;

public class DirectorConfigurations : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
            builder.HasKey(e => e.Id).HasName("directors_pkey");

            builder.ToTable("directors");

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
