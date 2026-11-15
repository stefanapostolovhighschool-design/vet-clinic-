using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VetClinic.Data.Entities;

namespace VetClinic.Data;

public class VetClinicDbContext : IdentityDbContext<ApplicationUser>
{
    public VetClinicDbContext(DbContextOptions<VetClinicDbContext> options)
        : base(options)
    {
    }

    public DbSet<Veterinarian> Veterinarians => Set<Veterinarian>();

    public DbSet<WorkSchedule> WorkSchedules => Set<WorkSchedule>();

    public DbSet<Species> Species => Set<Species>();

    public DbSet<Pet> Pets => Set<Pet>();

    public DbSet<Appointment> Appointments => Set<Appointment>();

    public DbSet<Examination> Examinations => Set<Examination>();

    public DbSet<Medication> Medications => Set<Medication>();

    public DbSet<Prescription> Prescriptions => Set<Prescription>();

    public DbSet<Vaccine> Vaccines => Set<Vaccine>();

    public DbSet<Vaccination> Vaccinations => Set<Vaccination>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(VetClinicDbContext).Assembly);
    }
}
