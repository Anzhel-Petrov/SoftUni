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
            var cars = File.ReadAllText("../../../Datasets/cars.json");
            var customers = File.ReadAllText("../../../Datasets/customers.json");
            var sales = File.ReadAllText("../../../Datasets/sales.json");

            //Console.WriteLine(ImportSuppliers(context, suppliers));
            //Console.WriteLine(ImportParts(context, parts));
            //Console.WriteLine(ImportCars(context, cars));
            //Console.WriteLine(ImportCustomers(context, customers));
            //Console.WriteLine(ImportSales(context, sales));
            Console.WriteLine(GetOrderedCustomers(context));
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

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsObj = new[]
            { new
                {
                    make = string.Empty,
                    model = string.Empty,
                    traveledDistance = int.MaxValue,
                    partsId = new [] {int.MaxValue}
                }
            };

            //var cars = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);
            var cars = JsonConvert.DeserializeAnonymousType(inputJson, carsObj);
            var partIds = context.Parts.Select(p => p.Id).ToList();
            ICollection<Car> carsToAdd = new List<Car>();

            foreach (var car in cars)
            {
                Car currentCar = new Car()
                {
                    Make = car.make,
                    Model = car.model,
                    TraveledDistance = car.traveledDistance
                };

                foreach (var carPart in car.partsId.Distinct())
                {
                    if (partIds.Contains(carPart))
                    {
                        currentCar.PartsCars.Add(new PartCar(){ Car = currentCar, PartId = carPart });
                    }
                }

                carsToAdd.Add(currentCar);
            }

            context.Cars.AddRange(carsToAdd);
            context.SaveChanges();
            return $"Successfully imported {cars.Length}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Length}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            //var customerIds = context.Customers.Select(c => c.Id);
            //var carIds = context.Cars.Select(c => c.Id);
            //var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            //ICollection<Sale> salesToAdd = new List<Sale>();

            //foreach (var sale in sales)
            //{
            //    if (customerIds.Contains(sale.CustomerId) && carIds.Contains(sale.CarId))
            //    {
            //        salesToAdd.Add(sale);
            //    }
            //}

            //context.Sales.AddRange(salesToAdd);
            //context.SaveChanges();
            //return $"Successfully imported {salesToAdd.Count}.";

            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson)!;
            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Length}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate).ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    c.IsYoungDriver
                })
                .AsEnumerable();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }
    }
}