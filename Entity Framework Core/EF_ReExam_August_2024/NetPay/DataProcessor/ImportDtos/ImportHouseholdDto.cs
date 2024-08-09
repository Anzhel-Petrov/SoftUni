using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static NetPay.Data.DataConstraints;
using NetPay.Data;
using NetPay.Data.Models;

namespace NetPay.DataProcessor.ImportDtos;

[XmlType(nameof(Household))]
public class ImportHouseholdDto
{
    [Required]
    [XmlElement(nameof(ContactPerson))]
    [MinLength(HouseholdContactPersonMinLength)]
    [MaxLength(HouseholdContactPersonMaxLength)]
    public string ContactPerson { get; set; } = null!;

    [XmlElement(nameof(Email))]
    [MinLength(HouseholdEmailMinLength)]
    [MaxLength(HouseholdEmailMaxLength)]
    public string? Email { get; set; }

    [Required]
    [XmlAttribute("phone")]
    [StringLength(HouseholdPhoneNumberLength, MinimumLength = HouseholdPhoneNumberLength)]
    [RegularExpression(HouseHoldPhoneNumberRegex)]
    public string PhoneNumber { get; set; } = null!;

}