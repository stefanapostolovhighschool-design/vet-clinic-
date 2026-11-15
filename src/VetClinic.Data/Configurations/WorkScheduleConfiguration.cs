using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetClinic.Data.Entities;

namespace VetClinic.Data.Configurations;

public class WorkScheduleConfiguration : IEntityTypeConfiguration<WorkSchedule>
{
    public void Configure(EntityTypeBuilder<WorkSchedule> builder)
    {
        builder.HasIndex(s => new { s.VeterinarianId, s.DayOfWeek }).IsUnique();

        builder.HasOne(s => s.Veterinarian)
            .WithMany(v => v.WorkSchedules)
            .HasForeignKey(s => s.VeterinarianId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(t => t.HasCheckConstraint("CK_WorkSchedules_EndAfterStart", "[EndTime] > [StartTime]"));
    }
}
