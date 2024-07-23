using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Cadastre.Data.DataConstraints;

namespace Cadastre.Data.Models;

public class Property
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(PropertyIdentifierMaxLength)]
    public string PropertyIdentifier { get; set; } = null!;

    [Required]
    public int Area { get; set; }

    [MaxLength(DetailsMaxLength)]
    public string? Details { get; set; }

    [Required]
    [MaxLength(AddressMaxLength)]
    public string Address { get; set; } = null!;

    public DateTime DateOfAcquisition { get; set; }

    public int DistrictId { get; set; }

    [ForeignKey(nameof(DistrictId))]
    public virtual District District { get; set; } = null!;

    public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = new HashSet<PropertyCitizen>();
}