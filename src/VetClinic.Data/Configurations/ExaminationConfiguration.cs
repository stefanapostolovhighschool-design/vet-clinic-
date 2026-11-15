using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetClinic.Data.Entities;

namespace VetClinic.Data.Configurations;

public class ExaminationConfiguration : IEntityTypeConfiguration<Examination>
{
    public void Configure(EntityTypeBuilder<Examination> builder)
    {
        builder.Property(e => e.Complaint).HasMaxLength(1000);
        builder.Property(e => e.Diagnosis).IsRequired().HasMaxLength(1000);
        builder.Property(e => e.Notes).HasMaxLength(2000);

        builder.HasOne(e => e.Pet)
            .WithMany(p => p.Examinations)
            .HasForeignKey(e => e.PetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Veterinarian)
            .WithMany(v => v.Examinations)
            .HasForeignKey(e => e.VeterinarianId)
            .OnDelete(DeleteBehavior.Restrict);

        // SQL Server does not allow ON DELETE SET NULL here, because deleting a pet
        // would reach examinations through two paths (directly and via appointments).
        builder.HasOne(e => e.Appointment)
            .WithOne(a => a.Examination)
            .HasForeignKey<Examination>(e => e.AppointmentId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
