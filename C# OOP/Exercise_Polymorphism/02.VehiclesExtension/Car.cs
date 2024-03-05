namespace _02.VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double _additionalFuelConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelIndex { get => _additionalFuelConsumption; }
    }
}
