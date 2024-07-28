using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Medicines.Data.Models;
using static Medicines.Data.DataConstraints;

namespace Medicines.DataProcessor.ImportDtos;

[XmlType(nameof(Medicine))]
public class ImportMedicineDto
{
    [Required]
    [XmlElement(nameof(Name))]
    [MinLength(MedicineNameMinLength)]
    [MaxLength(MedicineNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement(nameof(Price))]
    [Range((double)MedicinePriceMinRange, (double)MedicinePriceMaxRange)]
    public decimal Price { get; set; }

    [Required]
    [XmlAttribute("category")]
    [EnumDataType(typeof(Category))]
    public int Category { get; set; }

    [Required]
    public string ProductionDate { get; set; } = null!;

    [Required] 
    public string ExpiryDate { get; set; } = null!;

    [Required]
    [MinLength(MedicineProducerMinLength)]
    [MaxLength(MedicineProducerMaxLength)]
    public string Producer { get; set; } = null!;

}