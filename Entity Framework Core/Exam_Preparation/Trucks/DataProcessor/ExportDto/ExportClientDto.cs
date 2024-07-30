using Newtonsoft.Json;

namespace Trucks.DataProcessor.ExportDto;

[JsonObject]
public class ExportClientDto
{
    public string Name { get; set; } = null!;

    public ExportTruckDto[] Trucks { get; set; } = null!;
}