using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetClinic.Data.Entities;

namespace VetClinic.Data.Configurations;

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.Property(p => p.Dosage).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Instructions).HasMaxLength(500);

        builder.HasOne(p => p.Examination)
            .WithMany(e => e.Prescriptions)
            .HasForeignKey(p => p.ExaminationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Medication)
            .WithMany(m => m.Prescriptions)
            .HasForeignKey(p => p.MedicationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
