using System;
using System.Linq;

namespace _02.VehiclesExtension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            double carFuelQuantity = double.Parse(carTokens[0]);
            double carFuelConsumption = double.Parse(carTokens[1]);
            double carTankCapacity = double.Parse(carTokens[2]);

            IVehicle car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);

            string[] truckTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            double truckQuantity = double.Parse(truckTokens[0]);
            double truckFuelConsumption = double.Parse(truckTokens[1]);
            double truckTankCapacity = double.Parse(truckTokens[2]);


            IVehicle truck = new Truck(truckQuantity, truckFuelConsumption, truckTankCapacity);

            string[] busTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            double busQuantity = double.Parse(busTokens[0]);
            double busFuelConsumption = double.Parse(busTokens[1]);
            double busTankCapacity = double.Parse(busTokens[2]);


            IVehicle bus = new Bus(busQuantity, busFuelConsumption, busTankCapacity);

            int commandsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsNumber; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = tokens[0];
                string vehicle = tokens[1];
                double distanceOrFuel = double.Parse(tokens[2]);

                switch (command)
                {
                    case "Drive" when vehicle is "Car":
                        car.Drive(distanceOrFuel);
                        break;
                    case "Drive" when vehicle is "Truck":
                        truck.Drive(distanceOrFuel);
                        break;
                    case "Drive" when vehicle is "Bus":
                        bus.Drive(distanceOrFuel);
                        break;
                    case "DriveEmpty" when vehicle is "Bus":
                        bus.DriveEmpty(distanceOrFuel);
                        break;
                    case "Refuel" when vehicle is "Car":
                        car.Refuel(distanceOrFuel);
                        break;
                    case "Refuel" when vehicle is "Truck":
                        truck.Refuel(distanceOrFuel);
                        break;
                    case "Refuel" when vehicle is "Bus":
                        bus.Refuel(distanceOrFuel);
                        break;
                }

                //if (command == "Drive")
                //{
                //    if (vehicle == "Car")
                //    {
                //        car.Drive(distanceOrFuel);
                //    }
                //    else
                //    {
                //        truck.Drive(distanceOrFuel);
                //    }
                //}
                //else
                //{
                //    if (vehicle == "Car")
                //    {
                //        car.Refuel(distanceOrFuel);
                //    }
                //    else
                //    {
                //        truck.Refuel(distanceOrFuel);
                //    }
                //}
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
