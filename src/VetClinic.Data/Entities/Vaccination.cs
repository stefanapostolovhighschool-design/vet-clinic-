namespace VetClinic.Data.Entities;

public class Vaccination
{
    public int Id { get; set; }

    public int PetId { get; set; }

    public Pet Pet { get; set; } = null!;

    public int VaccineId { get; set; }

    public Vaccine Vaccine { get; set; } = null!;

    public int VeterinarianId { get; set; }

    public Veterinarian Veterinarian { get; set; } = null!;

    public DateOnly AdministeredOn { get; set; }

    public DateOnly NextDueOn { get; set; }

    public string? BatchNumber { get; set; }
}
