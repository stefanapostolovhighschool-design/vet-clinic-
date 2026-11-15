using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetClinic.Data.Entities;

namespace VetClinic.Data.Configurations;

public class VeterinarianConfiguration : IEntityTypeConfiguration<Veterinarian>
{
    public void Configure(EntityTypeBuilder<Veterinarian> builder)
    {
        builder.Property(v => v.Specialization).HasMaxLength(100);
        builder.Property(v => v.Bio).HasMaxLength(1000);

        builder.HasIndex(v => v.UserId).IsUnique();

        builder.HasOne(v => v.User)
            .WithOne(u => u.Veterinarian)
            .HasForeignKey<Veterinarian>(v => v.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
