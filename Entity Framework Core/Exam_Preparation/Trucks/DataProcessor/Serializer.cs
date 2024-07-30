using JSON_XML_Extensions;
using Trucks.DataProcessor.ExportDto;

namespace Trucks.DataProcessor
{
    using Data;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            ExportDespatcherDto[] despatchers = context.Despatchers
                .Where(d => d.Trucks.Any())
                .ToArray()
                .Select(d => new ExportDespatcherDto()
                {
                    Name = d.Name,
                    TrucksCount = d.Trucks.Count.ToString(),
                    Trucks = d.Trucks.Select(t => new ExportXmlTruckDto()
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        MakeType = t.MakeType.ToString()
                    })
                    .OrderBy(t => t.RegistrationNumber)
                    .ToArray()
                })
                .OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.Name)
                .ToArray();

            return despatchers.SerializeToXml("Despatchers");
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            ExportClientDto[] clients = context.Clients
                .Where(c => c.ClientsTrucks.Any(t => t.Truck.TankCapacity >= capacity))
                .Select(c => new ExportClientDto()
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                        .Where(t => t.Truck.TankCapacity >= capacity)
                        .Select(t => t.Truck)
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CargoCapacity)
                        .Select(t => new ExportTruckDto()
                        {
                            TruckRegistrationNumber = t.RegistrationNumber,
                            VinNumber = t.VinNumber,
                            TankCapacity = t.TankCapacity,
                            CargoCapacity = t.CargoCapacity,
                            CategoryType = t.CategoryType.ToString(),
                            MakeType = t.MakeType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToArray();

            //var clients = context
            //    .Clients
            //    .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
            //    .ToArray()
            //    .Select(c => new
            //    {
            //        c.Name,
            //        Trucks = c.ClientsTrucks
            //            .Where(ct => ct.Truck.TankCapacity >= capacity)
            //            .ToArray()
            //            .OrderBy(ct => ct.Truck.MakeType.ToString())
            //            .ThenByDescending(ct => ct.Truck.CargoCapacity)
            //            .Select(ct => new
            //            {
            //                TruckRegistrationNumber = ct.Truck.RegistrationNumber,
            //                VinNumber = ct.Truck.VinNumber,
            //                TankCapacity = ct.Truck.TankCapacity,
            //                CargoCapacity = ct.Truck.CargoCapacity,
            //                CategoryType = ct.Truck.CategoryType.ToString(),
            //                MakeType = ct.Truck.MakeType.ToString()
            //            })
            //            .ToArray()
            //    })
            //    .OrderByDescending(c => c.Trucks.Length)
            //    .ThenBy(c => c.Name)
            //    .Take(10)
            //    .ToArray();

            return clients.SerializationToJson();
        }
    }
}
