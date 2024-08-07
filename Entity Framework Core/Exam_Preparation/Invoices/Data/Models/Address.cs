﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Data.Models;

public class Address
{
    [Key] public int Id { get; set; }
    [MinLength(10)] [MaxLength(20)] public string StreetName { get; set; } = null!;
    public int StreetNumber { get; set; }
    public string PostCode { get; set; } = null!;
    [MinLength(5)] [MaxLength(15)] public string City { get; set; } = null!;
    [MinLength(5)] [MaxLength(15)] public string Country { get; set; } = null!;
    public int ClientId { get; set; }
    [ForeignKey(nameof(ClientId))] public virtual Client? Client { get; set; }
}