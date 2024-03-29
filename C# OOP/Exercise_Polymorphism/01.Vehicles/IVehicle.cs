﻿namespace _01.Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        void Drive(double distance);
        void Refuel(double liters);
    }
}
