using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Boardgames.Data.Models.Enums;

namespace Boardgames.DataProcessor.ImportDto;

[XmlType("Boardgame")]
public class BoardgameDto
{
    [XmlElement("Name")] [MinLength(10)] [MaxLength(20)] public string Name { get; set; } = null!;
    [XmlElement("Rating")] [Range(1, 10.00)] public double Rating { get; set; }
    [XmlElement("YearPublished")] [Range(2018, 2023)] public int YearPublished { get; set; }
    [XmlElement("CategoryType")] [EnumDataType(typeof(CategoryType))] public int CategoryType { get; set; }
    [XmlElement("Mechanics")] public string Mechanics { get; set; } = null!;
}