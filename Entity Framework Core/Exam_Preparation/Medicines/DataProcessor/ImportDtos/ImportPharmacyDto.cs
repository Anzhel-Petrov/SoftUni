using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Medicines.Data.Models;
using static Medicines.Data.DataConstraints;

namespace Medicines.DataProcessor.ImportDtos;

[XmlType(nameof(Pharmacy))]
public class ImportPharmacyDto
{
    [Required]
    [XmlElement(nameof(Name))]
    [MinLength(PharmacyNameMinLength)]
    [MaxLength(PharmacyNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement(nameof(PhoneNumber))]
    [MinLength(PharmacyPhoneLength)]
    [MaxLength(PharmacyPhoneLength)]
    [RegularExpression(PharmacyPhoneNumberRegex)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [XmlAttribute("non-stop")]
    [RegularExpression(PharmacyBooleanRegex)]
    public string IsNonStop { get; set; } = null!;

    [Required]
    [XmlArray(nameof(Medicines))]
    [XmlArrayItem(nameof(Medicine))]
    public ImportMedicineDto[] Medicines { get; set; } = null!;
}