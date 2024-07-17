using Invoices.DataProcessor.ExportDto;
using Invoices.DataProcessor.ExportDto.JSON;
using Invoices.Extensions;

namespace Invoices.DataProcessor
{
    using Invoices.Data;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            ExportClientXmlDto[] clients = context.Clients
                .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                .Select(c => new ExportClientXmlDto()
                {
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    InvoicesCount = c.Invoices.Count,
                    Invoices = c.Invoices
                        .OrderBy(i => i.IssueDate)
                        .ThenByDescending(i => i.DueDate)
                        .Select(i => new ExportInvoiceXmlDto()
                        {
                            InvoiceNumber = i.Number,
                            InvoiceAmount = (double)i.Amount,
                            DueDate = i.DueDate.ToString("MM/dd/yyyy"),
                            Currency = i.CurrencyType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(c => c.InvoicesCount)
                .ThenBy(c => c.ClientName)
                .ToArray();

            return clients.SerializeToXmlStream("Clients");
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            // var productsAnonymousObject = context.Products
            //     .Where(p => p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
            //     .Select(p => new
            //     {
            //         Name = p.Name,
            //         Price = (double)p.Price,
            //         //Price = decimal.TryParse(p.Price.ToString("0.##")),
            //         Category = p.CategoryType,
            //         Clients = p.ProductsClients
            //             .Where(pc => pc.Client.Name.Length >= nameLength)
            //             .Select(pc => new
            //             {
            //                 Name = pc.Client.Name,
            //                 NumberVat = pc.Client.NumberVat
            //             })
            //             .OrderBy(cp => cp.Name)
            //             .ToArray()
            //     })
            //     .OrderByDescending(c => c.Clients.Length)
            //     .ThenBy(c => c.Name)
            //     .Take(5)
            //     .ToArray();
            
            ProductsWithMostClientsDto[] products = context.Products
                .Where(p => p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
                .Select(p => new ProductsWithMostClientsDto()
                {
                    Name = p.Name,
                    Price = (double)p.Price,
                    //Price = decimal.TryParse(p.Price.ToString("0.##")),
                    Category = p.CategoryType,
                    Clients = p.ProductsClients
                        .Where(pc => pc.Client.Name.Length >= nameLength)
                        .Select(pc => new ExportClientDto()
                        {
                            Name = pc.Client.Name,
                            NumberVat = pc.Client.NumberVat
                        })
                        .OrderBy(cp => cp.Name)
                        .ToArray()
                })
                .OrderByDescending(c => c.Clients.Length)
                .ThenBy(c => c.Name)
                .Take(5)
                .ToArray();

            return products.SerializationToJson();
        }
    }
}