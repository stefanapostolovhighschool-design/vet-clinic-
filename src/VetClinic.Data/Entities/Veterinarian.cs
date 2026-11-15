namespace VetClinic.Data.Entities;

public class Veterinarian
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public ApplicationUser User { get; set; } = null!;

    public string? Specialization { get; set; }

    public string? Bio { get; set; }

    public ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public ICollection<Examination> Examinations { get; set; } = new List<Examination>();

    public ICollection<Vaccination> Vaccinations { get; set; } = new List<Vaccination>();
}
