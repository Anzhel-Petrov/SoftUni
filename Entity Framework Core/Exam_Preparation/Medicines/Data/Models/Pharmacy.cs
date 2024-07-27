using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Diagnostics;
using static Medicines.Data.DataConstraints;

namespace Medicines.Data.Models;

public class Pharmacy
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(PharmacyNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(PharmacyPhoneLength)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public bool IsNonStop { get; set; }

    public virtual ICollection<Medicine> Medicines { get; set; } = new HashSet<Medicine>();
}