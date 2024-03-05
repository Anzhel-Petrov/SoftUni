using System;

namespace _04.WildFarm.Factory
{
    public class FoodFactory
    {
        public static IFood GetFood(string[] foodTokens)
        {
            string type = foodTokens[0];
            int quantity = int.Parse(foodTokens[1]);

            IFood food = type switch
            {
                "Vegetable" => new Vegetable(quantity),
                "Fruit" => new Fruit(quantity),
                "Meat" => new Meat(quantity),
                "Seeds" => new Seeds(quantity),
                _ => throw new ArgumentException("Invalid food type!"),
            };

            return food;
        }
    }
}
