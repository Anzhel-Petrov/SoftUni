using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Hen : Bird
    {
        private readonly double _foodWeighMultiplier = 0.35;
        private readonly List<string> _foods = new List<string>() { "Meat", "Vegetable", "Seeds", "Meat", "Fruit" };
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double FoodWeightMultiplier => _foodWeighMultiplier;

        public override List<string> Foods => _foods;

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck"); ;
        }
    }
}
