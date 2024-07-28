using System.Globalization;
using System.Text;
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
            throw new NotImplementedException();
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
                    Price = p.Price.ToString(CultureInfo.InvariantCulture),
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
