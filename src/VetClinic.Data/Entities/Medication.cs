namespace VetClinic.Data.Entities;

public class Medication
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
