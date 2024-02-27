using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            string[] personsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (string personInput in personsInput)
            {
                string[] personDetails = personInput.Split("=", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Person person = new Person(personDetails[0], decimal.Parse(personDetails[1]));
                    persons.Add(person);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            string[] productsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (string productInput in productsInput)
            {
                try
                {
                    string[] productDetails = productInput.Split("=");
                    Product product = new Product(productDetails[0], decimal.Parse(productDetails[1]));
                    products.Add(product);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                string[] productAndPerson = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = productAndPerson[0];
                string productName = productAndPerson[1];

                Person person = persons.Find(per => per.Name == personName);
                Product product = products.Find(prod => prod.Name == productName);

                if (person.CanBuyProduct(product))
                {
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
            }

            foreach (Person person in persons)
            {
                if (person.Products.Any())
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.Select(x => x.Name).ToArray())}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }
}
