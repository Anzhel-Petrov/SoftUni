using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Cadastre.Data.Enumerations;
using static Cadastre.Data.DataConstraints;

namespace Cadastre.Data.Models;

public class District
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(DistrictNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(PostalCodeLength)]
    public string PostalCode { get; set; } = null!;

    [Required]
    public Region Region { get; set; }

    public virtual ICollection<Property> Properties { get; set; } = new HashSet<Property>();
}