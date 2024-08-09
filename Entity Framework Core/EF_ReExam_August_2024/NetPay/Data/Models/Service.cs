﻿using System.ComponentModel.DataAnnotations;
using static NetPay.Data.DataConstraints;

namespace NetPay.Data.Models;

public class Service
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ServiceNameNameMaxLength)]
    public string ServiceName { get; set; } = null!;

    public virtual ICollection<Expense> Expenses { get; set; } = new HashSet<Expense>();
    public virtual ICollection<SupplierService> SuppliersServices { get; set; } = new HashSet<SupplierService>();

}