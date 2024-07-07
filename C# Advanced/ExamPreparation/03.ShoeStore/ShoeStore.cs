using System.Security.Cryptography.X509Certificates;

namespace _03.ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            this.Name = name;
            this.StorageCapacity = storageCapacity;
            this.Shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; set; }

        public int Count => Shoes.Count;

        public string AddShoe(Shoe shoe)
        {
            if (Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }

            Shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
        {
            List<Shoe> shoesToRemove = Shoes.FindAll(s => s.Material == material);

            foreach (Shoe shoe in shoesToRemove)
            {
                Shoes.Remove(shoe);
            }

            return shoesToRemove.Count;
        }

    }
}
