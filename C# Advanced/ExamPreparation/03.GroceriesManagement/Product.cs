using System.Text;

namespace GroceriesManagement
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name}: {Price:F2}$");
            return sb.ToString().Trim();
        }
    }
}
