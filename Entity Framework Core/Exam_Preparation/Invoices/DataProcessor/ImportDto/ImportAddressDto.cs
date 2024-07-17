using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto;

[XmlType("Address")]
public class ImportAddressDto
{
    [XmlElement("StreetName")]
    [MinLength(10)] [MaxLength(20)] public string StreetName { get; set; } = null!;
    [XmlElement("StreetNumber")]
    public int StreetNumber { get; set; }
    [XmlElement("PostCode")]
    public string PostCode { get; set; } = null!;
    [XmlElement("City")]
    [MinLength(5)] [MaxLength(15)] public string City { get; set; } = null!;
    [XmlElement("Country")]
    [MinLength(5)] [MaxLength(15)] public string Country { get; set; } = null!;
}