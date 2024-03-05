namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double _fuelConsumptionIndex = 1.6;
        private const double _refueTankIndex = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption, _fuelConsumptionIndex)
        {
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * _refueTankIndex);
        }
    }
}
