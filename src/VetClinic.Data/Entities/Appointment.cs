using VetClinic.Data.Enums;

namespace VetClinic.Data.Entities;

public class Appointment
{
    public int Id { get; set; }

    public int PetId { get; set; }

    public Pet Pet { get; set; } = null!;

    public int VeterinarianId { get; set; }

    public Veterinarian Veterinarian { get; set; } = null!;

    public DateTime StartsAt { get; set; }

    public int DurationMinutes { get; set; } = 30;

    public string? Reason { get; set; }

    public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public DateTime? CancelledOn { get; set; }

    public Examination? Examination { get; set; }
}
