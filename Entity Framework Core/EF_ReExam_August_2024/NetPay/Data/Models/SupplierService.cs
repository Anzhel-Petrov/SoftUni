using System.ComponentModel.DataAnnotations.Schema;

namespace NetPay.Data.Models;

public class SupplierService
{
    public int SupplierId { get; set; }

    [ForeignKey(nameof(SupplierId))]
    public virtual Supplier Supplier { get; set; } = null!;

    public int ServiceId { get; set; }

    [ForeignKey(nameof(ServiceId))]
    public virtual Service Service { get; set; } = null!;
}