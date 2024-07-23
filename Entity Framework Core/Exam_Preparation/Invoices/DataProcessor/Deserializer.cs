using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using Invoices.Data;
using Invoices.Data.Models;
using Invoices.DataProcessor.ImportDto;
using JSON_XML_Extensions;

namespace Invoices.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            ImportClientDto[] importClientDtos =
                xmlString.DeserializeFromXml<ImportClientDto[]>("Clients");

            List<Client> validClients = new List<Client>();
            foreach (var client in importClientDtos)
            {
                if (!IsValid(client))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var clientToAdd = new Client()
                {
                    Name = client.Name,
                    NumberVat = client.NumberVat
                };

                foreach (var address in client.Addresses!)
                {
                    if (!IsValid(address))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    clientToAdd.Addresses!.Add(new Address()
                    {
                        City = address.City,
                        Country = address.Country,
                        PostCode = address.PostCode,
                        StreetName = address.StreetName,
                        StreetNumber = address.StreetNumber
                    });
                }
                validClients.Add(clientToAdd);
                sb.AppendLine(string.Format(SuccessfullyImportedClients, clientToAdd.Name));
            }
            
            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return sb.ToString().Trim();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportInvoiceDto[] invoices = jsonString.DeserializeFromJson<ImportInvoiceDto[]>();

            List<Invoice> validInvoices = new List<Invoice>();
            var validClients = context.Clients.Select(c => c.Id).ToArray();
            
            foreach (var invoice in invoices)
            {
                if (!IsValid(invoice) || invoice.DueDate < invoice.IssueDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                if (invoice.DueDate == DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture) || invoice.IssueDate == DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                if (!validClients.Contains(invoice.ClientId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                // if (!Enum.IsDefined(typeof(CurrencyType), invoice.CurrencyType))
                // {
                //     sb.AppendLine(ErrorMessage);
                //     continue;
                // }

                Invoice invoiceToAdd = new Invoice()
                {
                    Number = invoice.Number,
                    IssueDate = invoice.IssueDate,
                    DueDate = invoice.DueDate,
                    ClientId = invoice.ClientId,
                    Amount = invoice.Amount,
                    CurrencyType = invoice.CurrencyType
                };
                
                validInvoices.Add(invoiceToAdd);
                sb.AppendLine(string.Format(SuccessfullyImportedInvoices, invoice.Number));
            }
            
            context.Invoices.AddRange(validInvoices);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportProductDto[] products = jsonString.DeserializeFromJson<ImportProductDto[]>();
            List<Product> validProducts = new List<Product>();
            int[] validClientIds = context.Clients.Select(c => c.Id).ToArray();
            //context.Parts.Any(p => p.Id == pdto.PartId))
            foreach (var product in products)
            {
                //if (!IsValid(product) || !validClientIds.Any(x => product.Clients.Contains(x)))
                if(!IsValid(product))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Product productToAdd = new Product()
                {
                    Name = product.Name,
                    Price = product.Price,
                    CategoryType = product.CategoryType
                };

                // if(!validClientIds.Any(x => product.Clients.Contains(x)))
                // {
                //     sb.AppendLine(ErrorMessage);
                //     continue;
                // }
                
                foreach (var clientId in product.Clients.Distinct())
                {
                    if (validClientIds.Contains(clientId))
                    {
                        productToAdd.ProductsClients!.Add(new ProductClient()
                        {
                            Product = productToAdd,
                            ClientId = clientId
                        });
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                    
                }
                
                validProducts.Add(productToAdd);
                sb.AppendLine(string.Format(SuccessfullyImportedProducts, product.Name, productToAdd.ProductsClients!.Count));
            }
            
            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
