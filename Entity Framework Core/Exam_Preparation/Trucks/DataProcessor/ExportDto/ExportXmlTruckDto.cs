using System.Xml.Serialization;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ExportDto;

[XmlType(nameof(Truck))]
public class ExportXmlTruckDto
{
    [XmlElement(nameof(RegistrationNumber))]
    public string RegistrationNumber { get; set; } = null!;
    
    [XmlElement("Make")]
    public string MakeType { get; set; } = null!;
}