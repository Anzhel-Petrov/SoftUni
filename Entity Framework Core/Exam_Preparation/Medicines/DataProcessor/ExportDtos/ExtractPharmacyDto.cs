using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static Medicines.Data.DataConstraints;

namespace Medicines.DataProcessor.ExportDtos;

[JsonObject]
public class ExtractPharmacyDto
{
    [Required]
    [JsonProperty(nameof(Name))]
    [MinLength(PharmacyNameMinLength)]
    [MaxLength(PharmacyNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(PhoneNumber))]
    [MaxLength(PharmacyPhoneLength)]
    [RegularExpression(PharmacyPhoneNumberRegex)]
    public string PhoneNumber { get; set; } = null!;
}