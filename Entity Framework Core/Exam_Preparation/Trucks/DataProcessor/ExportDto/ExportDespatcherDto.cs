using System.Xml.Serialization;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ExportDto;

[XmlType(nameof(Despatcher))]
public class ExportDespatcherDto
{
    [XmlElement("DespatcherName")]
    public string Name { get; set; } = null!;

    [XmlAttribute(nameof(TrucksCount))] 
    public string TrucksCount { get; set; } = null!;

    [XmlArray(nameof(Trucks))]
    public ExportXmlTruckDto[] Trucks { get; set; } = null!;

}