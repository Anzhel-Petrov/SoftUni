using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Data.Models;
using Trucks.Data.Models.Enums;
using static Trucks.Data.DataConstraints;

namespace Trucks.DataProcessor.ImportDto;

[XmlType(nameof(Truck))]
public class ImportTruckDto
{
    [Required]
    [XmlElement(nameof(RegistrationNumber))]
    [StringLength(TruckRegistrationNumberLength, MinimumLength = TruckRegistrationNumberLength)]
    [RegularExpression(TruckRegistrationNumberRegex)]
    public string? RegistrationNumber { get; set; }

    [Required]
    [XmlElement(nameof(VinNumber))]
    [StringLength(TruckVinNumberLength, MinimumLength = TruckVinNumberLength)]
    public string VinNumber { get; set; } = null!;

    [Required]
    [XmlElement(nameof(TankCapacity))]
    [Range(TruckTankCapacityMinRange, TruckTankCapacityMaxRange)]
    public int TankCapacity { get; set; }

    [Required]
    [XmlElement(nameof(CargoCapacity))]
    [Range(TruckCargoCapacityMinRange, TruckCargoCapacityMaxRange)]
    public int CargoCapacity { get; set; }

    [Required]
    [XmlElement(nameof(CategoryType))]
    [EnumDataType(typeof(CategoryType))]
    public int CategoryType { get; set; }

    [Required]
    [XmlElement(nameof(MakeType))]
    [EnumDataType(typeof(MakeType))]
    public int MakeType { get; set; }
}