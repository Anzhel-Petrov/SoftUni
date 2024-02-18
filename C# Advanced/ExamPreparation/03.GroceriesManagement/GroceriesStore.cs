using System.Text;

namespace GroceriesManagement
{
    public class GroceriesStore
    {
        public GroceriesStore(int capacity)
        {
            Capacity = capacity;
            Stall = new List<Product>();
            Turnover = 0;
        }

        public int Capacity { get; set; }
        public double Turnover { get; set; }
        public List<Product> Stall { get; set; }

        public void AddProduct(Product product)
        {
            if (Stall.Count < Capacity)
            {
                if (!Stall.Contains(Stall.Where(x => x.Name == product.Name).FirstOrDefault()))
                {
                    Stall.Add(product);
                }
            }
        }

        public bool RemoveProduct(string name)
        {
            return Stall.Remove(Stall.Where(x => x.Name == name).FirstOrDefault());
        }

        public string SellProduct(string name, double quantity)
        {
            Product product = Stall.Where(x => x.Name == name).FirstOrDefault();

            if (product is null)
            {
                return "Product not found";
            }
            else
            {
                double totalPrice = product.Price * quantity;
                Turnover += totalPrice;
                return $"{product.Name} - {totalPrice:F2}$";
            }
        }

        public string GetMostExpensive()
        {
            return Stall.OrderByDescending(x => x.Price).FirstOrDefault().ToString();
        }

        public string CashReport()
        {
            return $"Total Turnover: {Turnover:F2}$";
        }

        public string PriceList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Groceries Price List:");

            foreach (Product product in Stall)
            {
                sb.AppendLine(product.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
