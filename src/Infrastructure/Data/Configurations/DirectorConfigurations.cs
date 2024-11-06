using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class DirectorConfigurations : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.HasKey(e => e.Id).HasName("directors_pkey");

        builder.ToTable("directors");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Birthdate).HasColumnName("birthdate");
        builder.Property(e => e.FirstName).HasMaxLength(255).HasColumnName("first_name");
        builder.Property(e => e.LastName).HasMaxLength(255).HasColumnName("last_name");
    }
}
