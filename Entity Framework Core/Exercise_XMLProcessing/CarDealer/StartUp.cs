using System.Net.Http.Headers;
using AutoMapper;
using CarDealer.Data;
using System.Xml.Serialization;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Globalization;
using System.Text;
using System.Xml;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();
            string suppliers = File.ReadAllText("../../../Datasets/suppliers.xml");
            string parts = File.ReadAllText("../../../Datasets/parts.xml");
            string cars = File.ReadAllText("../../../Datasets/cars.xml");
            string customers = File.ReadAllText("../../../Datasets/customers.xml");
            string sales = File.ReadAllText("../../../Datasets/sales.xml");

            //Console.WriteLine(ImportSuppliers(context, suppliers));
            //Console.WriteLine(ImportParts(context, parts));
            //Console.WriteLine(ImportCars(context, cars));
            //Console.WriteLine(ImportCustomers(context, customers));
            //Console.WriteLine(ImportSales(context, sales));
            //Console.WriteLine(GetCarsWithDistance(context));
            //Console.WriteLine(GetCarsFromMakeBmw(context));
            //Console.WriteLine(GetLocalSuppliers(context));
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));
            Console.WriteLine(GetTotalSalesByCustomer(context));
        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));

            using StringReader reader = new StringReader(inputXml);
            ImportSupplierDto[] importSupplierDtOs = (ImportSupplierDto[])serializer.Deserialize(reader)!;

            Mapper mapper = GetMapper();
            Supplier[] suppliers = mapper.Map<Supplier[]>(importSupplierDtOs);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            using StringReader reader = new StringReader(inputXml);
            ImportPartDto[] importPartDtOs = (ImportPartDto[])serializer.Deserialize(reader)!;

            var supplierIds = context.Suppliers.Select(s => s.Id).ToArray();

            Mapper mapper = GetMapper();
            Part[] parts = mapper.Map<Part[]>(importPartDtOs.Where(p => supplierIds.Contains(p.SupplierId)));

            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            //int[] validParts = context.Parts.Select(p => p.Id).ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));

            using StringReader reader = new StringReader(inputXml);
            ImportCarDto[] importCarDtOs = (ImportCarDto[])serializer.Deserialize(reader)!;

            Mapper mapper = GetMapper();
            List<Car> carsToAdd = new List<Car>();

            foreach (var carDto in importCarDtOs)
            {
                Car car = mapper.Map<Car>(carDto);

                //int[] carParts = carDto.Parts
                //    .Select(x => x.PartId)
                //    .Distinct()
                //    .ToArray();

                //var parts = carDto.Parts
                //    .Where(pdto => context.Parts.Any(p => p.Id == pdto.PartId))
                //    .Select(p => p.PartId)
                //    .Distinct();

                var carParts = new List<PartCar>();

                foreach (var partId in carDto.Parts.Select(p => p.PartId).Distinct())
                {
                    //if (context.Parts.Select(p => p.Id).Contains(partId))
                    if(context.Parts.Any(p => p.Id == partId))
                    {
                        carParts.Add(new PartCar()
                        {
                            Car = car,
                            PartId = partId
                        });
                    }
                }

                car.PartsCars = carParts;
                carsToAdd.Add(car);
            }

            context.Cars.AddRange(carsToAdd);
            context.SaveChanges();

            return $"Successfully imported {carsToAdd.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            using StringReader reader = new StringReader(inputXml);

            ImportCustomerDto[] importCustomerDtOs = (ImportCustomerDto[])serializer.Deserialize(reader);

            Mapper mapper = GetMapper();
            Customer[] customers = mapper.Map<Customer[]>(importCustomerDtOs);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));

            ImportSaleDto[] importSaleDtos;
            using (var reader = new StringReader(inputXml))
            {
                importSaleDtos = (ImportSaleDto[])serializer.Deserialize(reader)!;
            }

            Sale[] sales = importSaleDtos
                .Where(p => context.Cars.Select(c => c.Id).Contains(p.CarId))
                .Select(s => new Sale
                {
                    CarId = s.CarId,
                    CustomerId = s.CustomerId,
                    Discount = s.Discount
                })
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carsWithDistance = context.Cars
                .Select(c => new ExportCarDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            return SerializeToXml(carsWithDistance, "cars");
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmw = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new CarBMWExportDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();

            return SerializeToXml(bmw, "cars", true);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new SupplierExportDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            return SerializeToXml(localSuppliers, "suppliers");
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new CarWithParts()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars
                        .OrderByDescending(p => p.Part.Price)
                        .Select(pc => new ExportPartDto()
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price,
                        })
                        .ToArray()
                })
                .ToArray();

            return SerializeToXml(carsWithParts, "cars");
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var temp = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SalesInfo = c.Sales.Select(s => new
                    {
                        Prices = c.IsYoungDriver
                            ? s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2))
                            : s.Car.PartsCars.Sum(pc => (double)pc.Part.Price)
                    })
                    .ToArray()
                })
                .ToArray();

            var customerSalesInfo = temp
                .OrderByDescending(x => x.SalesInfo.Sum(y => y.Prices))
                .Select(a => new CustomerExportDto()
                {
                    FullName = a.FullName,
                    BoughtCars = a.BoughtCars,
                    SpentMoney = a.SalesInfo.Sum(b => (decimal)b.Prices)
                })
                .ToArray();

            return SerializeToXml(customerSalesInfo, "customers");
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {

        }

        private static string SerializeToXml<T>(T dto, string xmlRootAttribute, bool omitDeclaration = false)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));

            StringBuilder stringBuilder = new StringBuilder();

            XmlWriterSettings settings = new XmlWriterSettings()
            {
                OmitXmlDeclaration = omitDeclaration,
                Encoding = new UTF8Encoding(false),
                Indent = true
            };

            using (StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.InvariantCulture))
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add(string.Empty, string.Empty);

                try
                {
                    xmlSerializer.Serialize(xmlWriter, dto, xmlSerializerNamespaces);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return stringBuilder.ToString();
        }
    }
}