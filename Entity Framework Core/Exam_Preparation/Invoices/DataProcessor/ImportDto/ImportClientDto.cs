using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto;

[XmlType("Client")]
public class ImportClientDto
{
    [XmlElement("Name")]
    [MinLength(10)] [MaxLength(25)] public string Name { get; set; } = null!;
    [XmlElement("NumberVat")]
    [MinLength(10)] [MaxLength(15)] public string NumberVat { get; set; } = null!;
    [XmlArray("Addresses")]
    public ImportAddressDto[]? Addresses { get; set; }
}