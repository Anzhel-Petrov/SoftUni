using System.Xml.Serialization;
using CarDealer.Models;

namespace CarDealer.DTOs.Import;

[XmlType("Car")]
public class ImportCarDto
{
    [XmlElement("make")]
    public string Make { get; set; } = null!;
    [XmlElement("model")]
    public string Model { get; set; } = null!;
    [XmlElement("traveledDistance")]
    public long TraveledDistance { get; set; }
    [XmlArray("parts")]
    public ImportPartIdDto[] Parts { get; set; }
}