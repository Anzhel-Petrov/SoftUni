using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static Trucks.Data.DataConstraints;

namespace Trucks.DataProcessor.ImportDto;

public class ImportClientDto
{
    [Required]
    [JsonProperty(nameof(Name))]
    [MinLength(ClientNameMinLength)]
    [MaxLength(ClientNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(Nationality))]
    [MinLength(ClientNationalityMinLength)]
    [MaxLength(ClientNationalityMaxLength)]
    public string Nationality { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(Type))]
    //[RegularExpression(ClientTypeRegex)]
    public string Type { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(Trucks))]
    public int[] Trucks { get; set; } = null!;
}