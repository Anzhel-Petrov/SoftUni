using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            Vehicles = new List<Vehicle>();
            Capacity = capacity;
        }

        public List<Vehicle> Vehicles { get; set; }
        public int Capacity { get; set; }

        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count < Capacity)
            {
                Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            Vehicle? vehicle = Vehicles.Find(x => x.VIN == vin);
            if (vehicle is not null)
            {
                Vehicles.Remove(vehicle);
                return true;
            }
            return false;
        }

        public int GetCount()
        {
            return Vehicles.Count;
        }

        public Vehicle? GetLowestMileage()
        {
            return Vehicles.MinBy(x => x.Mileage);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");
            foreach (Vehicle vehicle in Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
