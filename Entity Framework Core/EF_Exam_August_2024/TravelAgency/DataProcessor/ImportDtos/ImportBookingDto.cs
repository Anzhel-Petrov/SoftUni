using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static TravelAgency.Data.DataConstraints;

namespace TravelAgency.DataProcessor.ImportDtos;

public class ImportBookingDto
{
    [Required] 
    public string BookingDate { get; set; } = null!;

    [Required]
    [MinLength(CustomerFullNameMinLength)]
    [MaxLength(CustomerFullNameMaxLength)]
    public string CustomerName { get; set; } = null!;

    [Required]
    [MinLength(TourPackageNameMinLength)]
    [MaxLength(TourPackageNameMaxLength)]
    public string TourPackageName { get; set; } = null!;
}