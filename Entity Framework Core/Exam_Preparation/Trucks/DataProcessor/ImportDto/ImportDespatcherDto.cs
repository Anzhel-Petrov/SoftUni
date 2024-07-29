using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Data.Models;
using static Trucks.Data.DataConstraints;

namespace Trucks.DataProcessor.ImportDto;

[XmlType(nameof(Despatcher))]
public class ImportDespatcherDto
{
    [Required]
    [XmlElement(nameof(Name))]
    [MinLength(DespatcherNameMinLength)]
    [MaxLength(DespatcherNameMaxLength)]
    public string Name { get; set; } = null!;

    //[Required]
    [XmlElement(nameof(Position))]
    public string? Position { get; set; }

    [Required] 
    [XmlArray(nameof(Trucks))]
    public ImportTruckDto[] Trucks { get; set; } = null!;
}