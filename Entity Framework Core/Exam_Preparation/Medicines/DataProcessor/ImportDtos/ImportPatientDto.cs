using Medicines.Data.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static Medicines.Data.DataConstraints;

namespace Medicines.DataProcessor.ImportDtos;

public class ImportPatientDto
{
    [Required]
    [JsonProperty(nameof(FullName))]
    [MinLength(PatientFullNameMinLength)]
    [MaxLength(PatientFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(AgeGroup))]
    [EnumDataType(typeof(AgeGroup))]
    public AgeGroup AgeGroup { get; set; }

    [Required]
    [JsonProperty(nameof(Gender))]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }

    [Required]
    [JsonProperty(nameof(Medicines))]
    public int[] Medicines { get; set; } = null!;

}