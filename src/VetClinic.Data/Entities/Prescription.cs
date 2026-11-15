namespace VetClinic.Data.Entities;

public class Prescription
{
    public int Id { get; set; }

    public int ExaminationId { get; set; }

    public Examination Examination { get; set; } = null!;

    public int MedicationId { get; set; }

    public Medication Medication { get; set; } = null!;

    public string Dosage { get; set; } = null!;

    public string? Instructions { get; set; }
}
