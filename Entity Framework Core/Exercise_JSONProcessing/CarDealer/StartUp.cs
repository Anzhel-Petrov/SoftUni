using System.Security.Cryptography.X509Certificates;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();

            var suppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            var parts = File.ReadAllText("../../../Datasets/parts.json");

            //Console.WriteLine(ImportSuppliers(context, suppliers));
            Console.WriteLine(ImportParts(context, parts));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson)!;
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Length}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var validSupplierIds = context.Suppliers.Select(s => s.Id).AsEnumerable();

            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)!;

            var partsWithValidSupplierId = parts.Where(p => validSupplierIds.Contains(p.SupplierId));

            context.Parts.AddRange(partsWithValidSupplierId);
            context.SaveChanges();
            return $"Successfully imported {partsWithValidSupplierId.Count()}.";
        }
    }
}