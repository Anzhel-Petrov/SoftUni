﻿using System.ComponentModel.DataAnnotations;
using Medicines.Data.Models.Enums;
using static Medicines.Data.DataConstraints;

namespace Medicines.Data.Models;

public class Patient
{
    [Key] 
    public int Id { get; set; }

    [Required]
    [MaxLength(PatientFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [Required]
    public AgeGroup AgeGroup { get; set; }

    [Required]
    public Gender Gender { get; set; }

    public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; } = new HashSet<PatientMedicine>();
}