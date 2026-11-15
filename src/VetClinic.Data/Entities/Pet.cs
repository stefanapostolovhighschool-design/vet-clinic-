using VetClinic.Data.Enums;

namespace VetClinic.Data.Entities;

public class Pet
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int SpeciesId { get; set; }

    public Species Species { get; set; } = null!;

    public string? Breed { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public PetSex Sex { get; set; }

    public decimal? WeightKg { get; set; }

    public string OwnerId { get; set; } = null!;

    public ApplicationUser Owner { get; set; } = null!;

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public ICollection<Examination> Examinations { get; set; } = new List<Examination>();

    public ICollection<Vaccination> Vaccinations { get; set; } = new List<Vaccination>();
}
