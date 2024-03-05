namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double _additionalFuelConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double  FuelIndex { get => _additionalFuelConsumption; }
    }
}
