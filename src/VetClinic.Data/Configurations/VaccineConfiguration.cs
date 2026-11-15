using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetClinic.Data.Entities;

namespace VetClinic.Data.Configurations;

public class VaccineConfiguration : IEntityTypeConfiguration<Vaccine>
{
    public void Configure(EntityTypeBuilder<Vaccine> builder)
    {
        builder.Property(v => v.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(v => v.Name).IsUnique();

        builder.ToTable(t => t.HasCheckConstraint("CK_Vaccines_ValidityMonths", "[ValidityMonths] BETWEEN 1 AND 60"));
    }
}
