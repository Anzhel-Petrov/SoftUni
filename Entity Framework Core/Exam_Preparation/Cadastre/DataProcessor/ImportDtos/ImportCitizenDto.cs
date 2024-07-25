using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static Cadastre.Data.DataConstraints;

namespace Cadastre.DataProcessor.ImportDtos;

[JsonObject(nameof(Citizen))]
public class ImportCitizenDto
{
    [Required]
    [JsonProperty(nameof(FirstName))]
    [MinLength(CitizenFirstNameMinLength)]
    [MaxLength(CitizenFirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(LastName))]
    [MinLength(CitizenLastNameMinLength)]
    [MaxLength(CitizenLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(BirthDate))]
    public string BirthDate { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(MaritalStatus))]
    [EnumDataType(typeof(MaritalStatus))]
    public string MaritalStatus { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(Properties))]
    public int[] Properties { get; set; } = null!;
}