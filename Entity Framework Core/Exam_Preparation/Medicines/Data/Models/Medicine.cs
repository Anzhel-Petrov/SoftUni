using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Medicines.Data.Models.Enums;
using static Medicines.Data.DataConstraints;

namespace Medicines.Data.Models;

public class Medicine
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(MedicineNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public Category Category { get; set; }

    [Required]
    public DateTime ProductionDate { get; set; }

    [Required]
    public DateTime ExpiryDate { get; set; }

    [Required]
    [MaxLength(MedicineProducerMaxLength)]
    public string Producer { get; set; } = null!;

    [Required]
    public int PharmacyId { get; set; }

    [ForeignKey(nameof(PharmacyId))]
    public Pharmacy Pharmacy { get; set; } = null!;
    public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; } = new HashSet<PatientMedicine>();
}