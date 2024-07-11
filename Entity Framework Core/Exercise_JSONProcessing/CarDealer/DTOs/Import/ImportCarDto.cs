using Newtonsoft.Json;

namespace CarDealer.DTOs.Import;

[JsonObject]
public class ImportCarDto
{
    [JsonProperty("make")]
    public string Make { get; set; }

    [JsonProperty("model")]
    public string Model { get; set; }

    [JsonProperty("travelledDistance")]
    public long TravelledDistance { get; set; }

    [JsonProperty("partsId")]
    public ICollection<int> PartCars { get; set; }
}