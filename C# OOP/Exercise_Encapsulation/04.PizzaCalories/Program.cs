using System;
using System.Linq;

namespace _04.PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {


            try
            {
                string[] pizzaInput = Console.ReadLine().Split(' ').Skip(1).ToArray();
                string pizzaName = pizzaInput[0];

                Pizza pizza = new Pizza(pizzaName);

                string[] doughInput = Console.ReadLine().Split(' ').Skip(1).ToArray();
                string flourType = doughInput[0];
                string bakingTecnique = doughInput[1];
                double doughGrams = double.Parse(doughInput[2]);

                pizza.Dough = new Dough(flourType, bakingTecnique, doughGrams);

                string input = "";
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingTokens = input.Split(' ').Skip(1).ToArray();
                    string toppingName = toppingTokens[0];
                    double toppingGrams = double.Parse(toppingTokens[1]);

                    Topping topping = new Topping(toppingName, toppingGrams);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
