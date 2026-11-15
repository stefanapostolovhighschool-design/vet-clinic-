namespace VetClinic.Data.Entities;

public class WorkSchedule
{
    public int Id { get; set; }

    public int VeterinarianId { get; set; }

    public Veterinarian Veterinarian { get; set; } = null!;

    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }
}
