using System.ComponentModel.DataAnnotations;
using Boardgames.Data.Models.Enums;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor.ExportDto;

public class ExportBoardgameDto
{
    [JsonProperty("Name")] public string Name { get; set; } = null!;
    [JsonProperty("Rating")] public double Rating { get; set; }
    [JsonProperty("Mechanics")] public string Mechanics { get; set; } = null!;
    [JsonProperty("Category")] [EnumDataType(typeof(CategoryType))] public CategoryType Category { get; set; }

}