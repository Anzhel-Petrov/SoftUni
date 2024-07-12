using System.Xml.Serialization;

namespace CarDealer.DTOs.Export;

[XmlType("car")]
public class CarBMWExportDto
{
    [XmlAttribute("id")]
    public int Id { get; set; }
    [XmlAttribute("model")]
    public string Model { get; set; }
    [XmlAttribute("traveled-distance")]
    public long TraveledDistance { get; set; }
}