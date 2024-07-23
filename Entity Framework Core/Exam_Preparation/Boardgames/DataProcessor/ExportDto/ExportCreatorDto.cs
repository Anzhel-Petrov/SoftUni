using System.Xml.Serialization;
using Boardgames.Data.Models;

namespace Boardgames.DataProcessor.ExportDto;

[XmlType(nameof(Creator))]
public class ExportCreatorDto
{
    [XmlAttribute(nameof(BoardgamesCount))]
    public string BoardgamesCount { get; set; } = null!;

    [XmlElement(nameof(CreatorName))]
    public string CreatorName { get; set; } = null!;

    [XmlArray(nameof(Boardgames))]
    public ExportXmlBoardgameDto[] Boardgames { get; set; } = null!;
}