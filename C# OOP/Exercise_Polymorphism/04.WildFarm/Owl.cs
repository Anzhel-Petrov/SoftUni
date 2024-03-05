using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Owl : Bird
    {
        private readonly double _foodWeighMultiplier = 0.25;
        private readonly List<string> _foods = new List<string>() { "Meat" };
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double FoodWeightMultiplier => _foodWeighMultiplier;

        public override List<string> Foods => _foods;

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot"); ;
        }
    }
}
