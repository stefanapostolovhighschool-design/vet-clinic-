using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetClinic.Data.Entities;

namespace VetClinic.Data.Configurations;

public class VaccinationConfiguration : IEntityTypeConfiguration<Vaccination>
{
    public void Configure(EntityTypeBuilder<Vaccination> builder)
    {
        builder.Property(v => v.BatchNumber).HasMaxLength(50);

        builder.HasIndex(v => v.NextDueOn);

        builder.HasOne(v => v.Pet)
            .WithMany(p => p.Vaccinations)
            .HasForeignKey(v => v.PetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(v => v.Vaccine)
            .WithMany(x => x.Vaccinations)
            .HasForeignKey(v => v.VaccineId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(v => v.Veterinarian)
            .WithMany(x => x.Vaccinations)
            .HasForeignKey(v => v.VeterinarianId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
