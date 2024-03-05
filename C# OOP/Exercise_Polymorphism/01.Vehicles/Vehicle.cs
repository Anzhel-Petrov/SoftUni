using System;

namespace _01.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, double fuelConsumptionIndex)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + fuelConsumptionIndex;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }

        public void Drive(double distance)
        {
            if (FuelQuantity > FuelConsumption * distance)
            {
                FuelQuantity -= FuelConsumption * distance;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }
    }
}
