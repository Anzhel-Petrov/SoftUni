using System;
using System.Linq;

namespace _01.Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            double carFuelQuantity = double.Parse(carTokens[0]);
            double carFuelConsumption = double.Parse(carTokens[1]);

            IVehicle car = new Car(carFuelQuantity, carFuelConsumption);

            string[] truckTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            double truckQuantity = double.Parse(truckTokens[0]);
            double truckFuelConsumption = double.Parse(truckTokens[1]);

            IVehicle truck = new Truck(truckQuantity, truckFuelConsumption);

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
                    case "Refuel" when vehicle is "Car":
                        car.Refuel(distanceOrFuel);
                        break;
                    case "Refuel" when vehicle is "Truck":
                        truck.Refuel(distanceOrFuel);
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
        }
    }
}
