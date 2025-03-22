namespace _03.OrdersAnotherSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string commandLine = default;
            var products = new Dictionary<string, double>();
            List<Product> productsList = new List<Product>();

            while ((commandLine = Console.ReadLine()) != "buy")
            {
                string[] splitCommand = commandLine.Split(" ");

                Product product = new Product()
                {
                    Name = splitCommand[0],
                    Price = double.Parse(splitCommand[1]),
                    Quantity = int.Parse(splitCommand[2])
                };

                if (products.ContainsKey(product.Name))
                {
                    double newQuantity = productsList.
                        Find(x => x.Name == product.Name).
                        Quantity += product.Quantity;
                    double newPrice = productsList.
                        Find(x => x.Name == product.Name).
                        Price = product.Price;

                    products[product.Name] = newQuantity * newPrice;
                }
                else
                {
                    productsList.Add(product);
                    products.Add(product.Name, product.Quantity * product.Price);
                }
            }

            foreach (var p in products)
            {
                Console.WriteLine($"{p.Key} -> {p.Value:f2}");
            }
        }

        public class Product
        {
            public Product()
            {

            }
            public string Name { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
        }
    }
}