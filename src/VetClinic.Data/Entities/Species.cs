namespace VetClinic.Data.Entities;

public class Species
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
