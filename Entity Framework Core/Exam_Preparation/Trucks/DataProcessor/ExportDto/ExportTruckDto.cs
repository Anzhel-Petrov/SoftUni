using Newtonsoft.Json;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ExportDto;

[JsonObject]
public class ExportTruckDto
{
    public string? TruckRegistrationNumber { get; set; }

    public string VinNumber { get; set; } = null!;

    public int TankCapacity { get; set; }

    public int CargoCapacity { get; set; }

    public string CategoryType { get; set; } = null!;

    public string MakeType { get; set; } = null!;
}