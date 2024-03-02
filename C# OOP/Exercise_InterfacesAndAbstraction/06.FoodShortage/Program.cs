using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int numberOfBuyers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBuyers; i++)
            {
                string[] buyersTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = buyersTokens[0];
                int age = int.Parse(buyersTokens[1]);

                if (buyersTokens.Length == 4)
                {
                    string id = buyersTokens[2];
                    string dateOfBirth = buyersTokens[3];
                    buyers.Add(new Citizen(name, age, id, dateOfBirth));
                }
                else
                {
                    string group = buyersTokens[2];
                    buyers.Add(new Rebel(name, age, group));
                }
            }

            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                foreach (IBuyer buyer in buyers.Where(x => x.Name == input))
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(x => x.Food));
        }
    }
}
