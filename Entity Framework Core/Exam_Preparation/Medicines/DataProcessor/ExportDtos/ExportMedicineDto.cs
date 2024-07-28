using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Medicines.Data.DataConstraints;

namespace Medicines.DataProcessor.ExportDtos;

[JsonObject]
public class ExportMedicineDto
{
    [Required]
    [JsonProperty(nameof(Name))]
    [MinLength(MedicineNameMinLength)]
    [MaxLength(MedicineNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(Price))]
    [Range((double)MedicinePriceMinRange, (double)MedicinePriceMaxRange)]
    public string Price { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(Pharmacy))]
    public ExtractPharmacyDto Pharmacy { get; set; } = null!;
}