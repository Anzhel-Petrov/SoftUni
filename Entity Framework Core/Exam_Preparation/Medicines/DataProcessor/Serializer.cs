using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using JSON_XML_Extensions;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ExportDtos;

namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Microsoft.EntityFrameworkCore;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            //DateTime givenDate;

            //if (!DateTime.TryParse(date, out givenDate))
            //{
            //    throw new ArgumentException("Invalid date format!");
            //}

            //ExportPatientDto[] patients = context.Patients.AsNoTracking()
            //    .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate >= givenDate))
            //    .Select(p => new ExportPatientDto
            //    {
            //        FullName = p.FullName,
            //        AgeGroup = p.AgeGroup.ToString(),
            //        Gender = p.Gender.ToString().ToLower(),
            //        Medicines = p.PatientsMedicines
            //            .Where(pm => pm.Medicine.ProductionDate >= givenDate)
            //            .Select(pm => pm.Medicine)
            //            .OrderByDescending(m => m.ExpiryDate)
            //            .ThenBy(m => m.Price)
            //            .Select(m => new ExportMedicineDto
            //            {
            //                Name = m.Name,
            //                Price = m.Price.ToString("F2"),
            //                Category = m.Category.ToString().ToLower(),
            //                Producer = m.Producer,
            //                ExpiryDate = m.ExpiryDate.ToString("yyyy-MM-dd")
            //            })
            //            .ToArray()
            //    })
            //    .OrderByDescending(p => p.Medicines.Length)
            //    .ThenBy(p => p.FullName)
            //    .ToArray();

            var patients = context.Patients
                .Where(p => p.PatientsMedicines.Any(m => m.Medicine.ProductionDate > DateTime.Parse(date)))
                .Select(p => new ExportPatientDto()
                {
                    Name = p.FullName,
                    AgeGroup = p.AgeGroup,
                    Gender = p.Gender.ToString().ToLowerInvariant(),
                    Medicines = p.PatientsMedicines
                        .Where(m => m.Medicine.ProductionDate > DateTime.Parse(date))
                        .OrderByDescending(m => m.Medicine.ExpiryDate)
                        .ThenBy(m => m.Medicine.Price)
                        .Select(m => new ExportXmlMedicineDto()
                        {
                            Name = m.Medicine.Name,
                            Price = m.Medicine.Price.ToString("F2", CultureInfo.InvariantCulture),
                            Producer = m.Medicine.Producer,
                            BestBefore = m.Medicine.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                            Category = m.Medicine.Category.ToString().ToLowerInvariant(),
                        })
                        .ToArray()
                })
                .OrderByDescending(p => p.Medicines.Length)
                .ThenBy(p => p.Name)
                .ToArray();

            //StringBuilder sb = new StringBuilder();

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPatientDto[]), new XmlRootAttribute("Properties"));
            //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //namespaces.Add(string.Empty, string.Empty);

            //using StringWriter writer = new StringWriter(sb);
            //xmlSerializer.Serialize(writer, patients, namespaces);

            //return sb.ToString().TrimEnd();

            return patients.SerializeToXml("Patients");
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {

            //var medicinesData = context.Medicines.AsNoTracking()
            //    .Where(m => m.Category == (Category)medicineCategory && m.Pharmacy.IsNonStop)
            //    .OrderBy(m => m.Price)
            //    .ThenBy(m => m.Name)
            //    .Select(m => new
            //    {
            //        Name = m.Name,
            //        Price = m.Price.ToString("F2"),
            //        Pharmacy = new
            //        {
            //            Name = m.Pharmacy.Name,
            //            PhoneNumber = m.Pharmacy.PhoneNumber
            //        }
            //    }).ToArray();

            var pharmacies = context.Medicines
                .Where(m => m.Category == (Category)medicineCategory && m.Pharmacy.IsNonStop)
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(p => new ExportMedicineDto()
                {
                    Name = p.Name,
                    Price = p.Price.ToString("F2", CultureInfo.InvariantCulture),
                    Pharmacy = new ExtractPharmacyDto()
                    {
                        Name = p.Pharmacy.Name,
                        PhoneNumber = p.Pharmacy.PhoneNumber
                    }
                })
                .ToArray();

            return pharmacies.SerializationToJson();
        }
    }
}
