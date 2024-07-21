using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto;

[XmlType("Creator")]
public class ImportCreatorDto
{
    [XmlElement("FirstName")] [MinLength(2)] [MaxLength(7)] public string FirstName { get; set; } = null!;
    [XmlElement("LastName")] [MinLength(2)] [MaxLength(7)] public string LastName { get; set; } = null!;
    [XmlArray("Boardgames")] public BoardgameDto[] Boardgames { get; set; } = null!;
}