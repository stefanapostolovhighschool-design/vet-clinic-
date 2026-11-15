using Microsoft.AspNetCore.Identity;

namespace VetClinic.Data.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public Veterinarian? Veterinarian { get; set; }

    public ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
