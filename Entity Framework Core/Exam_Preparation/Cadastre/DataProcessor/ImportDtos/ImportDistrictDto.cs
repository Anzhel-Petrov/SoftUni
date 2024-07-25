using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using static Cadastre.Data.DataConstraints;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlType(nameof(District))]
public class ImportDistrictDto
{
    [Required]
    [XmlAttribute(nameof(Region))]
    [EnumDataType(typeof(Region))]
    public string Region { get; set; } = null!;

    [Required]
    [XmlElement(nameof(Name))]
    [MinLength(DistrictNameMinLength)]
    [MaxLength(DistrictNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(PostalCodeLength)]
    [MaxLength(PostalCodeLength)]
    [RegularExpression(DistrictPostalCodeRegexExpression)]
    public string PostalCode { get; set; } = null!;

    [XmlArray(nameof(Properties))]
    public ImportPropertyDto[] Properties { get; set; } = null!;
}