using System.Xml.Serialization;
using TravelAgency.Data.Models;

namespace TravelAgency.DataProcessor.ExportDtos;

[XmlType(nameof(Guide))]
public class ExportGuideDto
{
    [XmlElement(nameof(FullName))]
    public string FullName { get; set; } = null!;

    [XmlArray(nameof(TourPackages))]
    public ExportTourPackageDto[] TourPackages { get; set; } = null!;
}