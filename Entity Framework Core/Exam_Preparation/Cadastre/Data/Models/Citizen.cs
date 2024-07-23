using System.ComponentModel.DataAnnotations;
using Cadastre.Data.Enumerations;
using static Cadastre.Data.DataConstraints;

namespace Cadastre.Data.Models;

public class Citizen
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CitizenFirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(CitizenLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public MaritalStatus MaritalStatus { get; set; }

    public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = new HashSet<PropertyCitizen>();
}