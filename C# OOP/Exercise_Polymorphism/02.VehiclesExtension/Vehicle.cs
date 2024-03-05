using System;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle : IVehicle
    {
        private double _fuelQuantity;
        private double _tankCapacity;
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelConsumption = fuelConsumption + FuelIndex;
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity 
        {
            get => _fuelQuantity;
            private set
            {
                if (value > TankCapacity)
                {
                    _fuelQuantity = 0;
                }
                else
                {
                    _fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; private set; }
        public double TankCapacity { get; private set; }
        public virtual double FuelIndex { get; set; }

        public virtual void Drive(double distance)
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

        public void DriveEmpty(double distance)
        {   
            FuelConsumption -= FuelIndex;
            Drive(distance);
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else if(fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                FuelQuantity += fuel;
            }
        }
    }
}
