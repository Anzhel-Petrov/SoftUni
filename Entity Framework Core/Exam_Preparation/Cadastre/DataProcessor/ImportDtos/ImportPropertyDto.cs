using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Cadastre.Data.Models;
using static Cadastre.Data.DataConstraints;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlType(nameof(Property))]
public class ImportPropertyDto
{
    [Required]
    [XmlElement(nameof(PropertyIdentifier))]
    [MinLength(PropertyIdentifierMinLength)]
    [MaxLength(PropertyIdentifierMaxLength)]
    public string PropertyIdentifier { get; set; } = null!;

    [Required]
    [XmlElement(nameof(Area))]
    [Range(AreaMinRange, AreaMaxRange)]
    public int Area { get; set; }

    [XmlElement(nameof(Details))]
    [MinLength(DetailsMinLength)]
    [MaxLength(DetailsMaxLength)]
    public string? Details { get; set; }

    [Required]
    [XmlElement(nameof(Address))]
    [MinLength(AddressMinLength)]
    [MaxLength(AddressMaxLength)]
    public string Address { get; set; } = null!;

    [Required]
    [XmlElement(nameof(DateOfAcquisition))]
    public string DateOfAcquisition { get; set; } = null!;
}