namespace _02.VehiclesExtension
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        double TankCapacity { get; }
        void Drive(double distance);
        void Refuel(double liters);
        void DriveEmpty(double distance);
    }
}
