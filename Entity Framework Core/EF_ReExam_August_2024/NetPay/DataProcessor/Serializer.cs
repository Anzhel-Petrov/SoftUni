using NetPay.Data;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ExportDtos;
using NetPay.Utilities;

namespace NetPay.DataProcessor
{
    public class Serializer
    {
        public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext context)
        {
            var households = context.Households
                .Where(hh => hh.Expenses.Any(e => e.PaymentStatus != PaymentStatus.Paid))
                .ToArray()
                .Select(h => new ExportHouseholdDto()
                {
                    ContactPerson = h.ContactPerson,
                    Email = h.Email,
                    PhoneNumber = h.PhoneNumber,
                    Expenses = h.Expenses
                        .Where(e => e.PaymentStatus != PaymentStatus.Paid)
                        .Select(e => new ExportExpenseDto()
                        {
                            ExpenseName = e.ExpenseName,
                            Amount = e.Amount.ToString("F2"),
                            PaymentDate = e.DueDate.ToString("yyyy-MM-dd"),
                            ServiceName = e.Service.ServiceName
                        })
                        .OrderBy(e => e.PaymentDate)
                        .ThenBy(e => e.Amount)
                        .ToArray()

                })
                .OrderBy(h => h.ContactPerson)
                .ToArray();

            return households.SerializeToXml("Households");
        }

        public static string ExportAllServicesWithSuppliers(NetPayContext context)
        {
            var services = context.Services
                .Select(s => new
                {
                    s.ServiceName,
                    Suppliers = s.SuppliersServices
                        .Select(ss => new
                        {
                            ss.Supplier.SupplierName
                        })
                        .OrderBy(ss => ss.SupplierName)
                        .ToArray()
                })
                .OrderBy(s => s.ServiceName)
                .ToArray();

            return services.SerializationToJson();
        }
    }
}
