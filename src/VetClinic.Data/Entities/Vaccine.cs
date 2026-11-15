namespace VetClinic.Data.Entities;

public class Vaccine
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ValidityMonths { get; set; }

    public ICollection<Vaccination> Vaccinations { get; set; } = new List<Vaccination>();
}
