using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trucks.Data.Models.Enums;
using static Trucks.Data.DataConstraints;

namespace Trucks.Data.Models;

public class Truck
{
    [Key]
    public int Id { get; set; }

    [MaxLength(TruckRegistrationNumberLength)]
    public string? RegistrationNumber { get; set; }

    [Required]
    [MaxLength(TruckVinNumberLength)]
    public string VinNumber { get; set; } = null!;

    [Required]
    public int TankCapacity { get; set; }

    [Required]
    public int CargoCapacity { get; set; }

    [Required]
    public CategoryType CategoryType { get; set; }

    [Required]
    public MakeType MakeType { get; set; }

    [Required]
    public int DespatcherId { get; set; }

    [ForeignKey(nameof(DespatcherId))] 
    public virtual Despatcher Despatcher { get; set; } = null!;

    public virtual ICollection<ClientTruck> ClientsTrucks { get; set; } = new HashSet<ClientTruck>();
}