using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VetClinic.Data;
using VetClinic.Data.Entities;

namespace VetClinic.Data.Tests;

public class VetClinicDbContextModelTests
{
    private static IModel BuildModel()
    {
        var options = new DbContextOptionsBuilder<VetClinicDbContext>()
            .UseSqlServer("Server=.;Database=ModelOnly")
            .Options;

        using var context = new VetClinicDbContext(options);
        return context.Model;
    }

    private static IForeignKey GetForeignKey(IModel model, Type dependent, Type principal)
        => model.FindEntityType(dependent)!
            .GetForeignKeys()
            .Single(fk => fk.PrincipalEntityType.ClrType == principal);

    [Theory]
    [InlineData(typeof(ApplicationUser))]
    [InlineData(typeof(Veterinarian))]
    [InlineData(typeof(WorkSchedule))]
    [InlineData(typeof(Species))]
    [InlineData(typeof(Pet))]
    [InlineData(typeof(Appointment))]
    [InlineData(typeof(Examination))]
    [InlineData(typeof(Medication))]
    [InlineData(typeof(Prescription))]
    [InlineData(typeof(Vaccine))]
    [InlineData(typeof(Vaccination))]
    public void Model_ContainsDomainEntity(Type entity)
    {
        Assert.NotNull(BuildModel().FindEntityType(entity));
    }

    [Fact]
    public void PetOwnerForeignKey_IsRestrict()
    {
        var fk = GetForeignKey(BuildModel(), typeof(Pet), typeof(ApplicationUser));

        Assert.Equal(DeleteBehavior.Restrict, fk.DeleteBehavior);
    }

    [Theory]
    [InlineData(typeof(Appointment))]
    [InlineData(typeof(Examination))]
    [InlineData(typeof(Vaccination))]
    public void ForeignKeysToVeterinarian_AreRestrict(Type entity)
    {
        var fk = GetForeignKey(BuildModel(), entity, typeof(Veterinarian));

        Assert.Equal(DeleteBehavior.Restrict, fk.DeleteBehavior);
    }

    [Theory]
    [InlineData(typeof(Appointment))]
    [InlineData(typeof(Examination))]
    [InlineData(typeof(Vaccination))]
    public void ForeignKeysToPet_AreCascade(Type entity)
    {
        var fk = GetForeignKey(BuildModel(), entity, typeof(Pet));

        Assert.Equal(DeleteBehavior.Cascade, fk.DeleteBehavior);
    }

    [Fact]
    public void ExaminationAppointmentForeignKey_IsSetNullAndUnique()
    {
        var fk = GetForeignKey(BuildModel(), typeof(Examination), typeof(Appointment));

        Assert.Equal(DeleteBehavior.ClientSetNull, fk.DeleteBehavior);
        Assert.True(fk.IsUnique);
    }

    [Theory]
    [InlineData(typeof(Vaccine), nameof(Vaccine.Name))]
    [InlineData(typeof(Species), nameof(Species.Name))]
    [InlineData(typeof(Medication), nameof(Medication.Name))]
    [InlineData(typeof(Veterinarian), nameof(Veterinarian.UserId))]
    public void Property_HasUniqueIndex(Type entity, string property)
    {
        var index = BuildModel().FindEntityType(entity)!
            .GetIndexes()
            .SingleOrDefault(i => i.Properties.Count == 1 && i.Properties[0].Name == property);

        Assert.NotNull(index);
        Assert.True(index!.IsUnique);
    }

    [Fact]
    public void WorkSchedule_IsUniquePerVeterinarianAndDay()
    {
        var index = BuildModel().FindEntityType(typeof(WorkSchedule))!
            .GetIndexes()
            .Single(i => i.Properties.Count == 2);

        Assert.True(index.IsUnique);
        Assert.Equal(
            new[] { nameof(WorkSchedule.VeterinarianId), nameof(WorkSchedule.DayOfWeek) },
            index.Properties.Select(p => p.Name));
    }

    [Fact]
    public void PetWeight_IsDecimal_5_2()
    {
        var property = BuildModel().FindEntityType(typeof(Pet))!.FindProperty(nameof(Pet.WeightKg))!;

        Assert.Equal("decimal(5,2)", property.GetColumnType());
    }

    [Fact]
    public void ExaminationDiagnosis_IsRequiredWithMaxLength1000()
    {
        var property = BuildModel().FindEntityType(typeof(Examination))!.FindProperty(nameof(Examination.Diagnosis))!;

        Assert.False(property.IsNullable);
        Assert.Equal(1000, property.GetMaxLength());
    }
}
