using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Clothes { get; set; } = new List<Cloth>();

        public void AddCloth(Cloth cloth)
        {
            if (this.Clothes.Count < this.Capacity)
            {
                this.Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            return this.Clothes.Remove(this.Clothes.Where(x => x.Color == color).FirstOrDefault());
        }

        public Cloth GetSmallestCloth()
        {
            return this.Clothes.MinBy(x => x.Size);
        }

        public Cloth GetCloth(string color)
        {
            return this.Clothes.Where(x => x.Color == color).FirstOrDefault();
        }

        public int GetClothCount()
        {
            return this.Clothes.Count;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Type} magazine contains:");
            foreach (Cloth cloth in this.Clothes.OrderBy(x => x.Size))
            {
                sb.AppendLine(cloth.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
