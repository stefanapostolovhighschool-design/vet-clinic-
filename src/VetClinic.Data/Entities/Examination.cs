namespace VetClinic.Data.Entities;

public class Examination
{
    public int Id { get; set; }

    public int PetId { get; set; }

    public Pet Pet { get; set; } = null!;

    public int VeterinarianId { get; set; }

    public Veterinarian Veterinarian { get; set; } = null!;

    public int? AppointmentId { get; set; }

    public Appointment? Appointment { get; set; }

    public DateTime ExaminedOn { get; set; }

    public string? Complaint { get; set; }

    public string Diagnosis { get; set; } = null!;

    public string? Notes { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
