using System.Xml.Serialization;
using Medicines.Data.Models;
using Medicines.Data.Models.Enums;

namespace Medicines.DataProcessor.ExportDtos;

[XmlType(nameof(Patient))]
public class ExportPatientDto
{
    [XmlElement(nameof(Name))]
    public string Name { get; set; } = null!;

    [XmlElement(nameof(AgeGroup))]
    public AgeGroup AgeGroup { get; set; }

    [XmlAttribute(nameof(Gender))]
    public string Gender { get; set; } = null!;

    [XmlArray(nameof(Medicines))]
    public ExportXmlMedicineDto[] Medicines { get; set; } = null!;
}