namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string command = "";
            while ((command = Console.ReadLine()) != "buy")
            {
                string[] arguments = command.Split();
                string name = arguments[0];
                decimal price = decimal.Parse(arguments[1]);
                int quantity = int.Parse(arguments[2]);

                if (products.ContainsKey(name))
                {
                    products[name].Update(price, quantity);
                }
                else
                {
                    Product product = new Product(name, price, quantity);
                    products.Add(name, product);
                }
            }

            Console.WriteLine(string.Join("\n", products.Values));
        }

        class Product
        {
            public Product(string name, decimal price, int quantity)
            {
                this.Name = name;
                this.Price = price;
                this.Quantity = quantity;
            }

            public string Name { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public int Quantity { get; set; }

            public void Update(decimal newPrice, int newQuantity)
            {
                Price = newPrice;
                Quantity += newQuantity;
            }

            public decimal TotalPrice()
            {
                return Price * Quantity;
            }

            public override string ToString()
            {
                return $"{Name} -> {TotalPrice()}";
            }
        }
    }
}
