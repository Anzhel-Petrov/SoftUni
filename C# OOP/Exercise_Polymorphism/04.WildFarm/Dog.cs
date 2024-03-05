using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Dog : Mammal
    {
        private readonly double _foodWeighMultiplier = 0.40;
        private readonly List<string> _foods = new List<string>() { "Meat" };
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double FoodWeightMultiplier => _foodWeighMultiplier;

        public override List<string> Foods => _foods;

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!"); ;
        }

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
