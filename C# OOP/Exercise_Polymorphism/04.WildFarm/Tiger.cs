using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Tiger : Feeline
    {
        private readonly double _foodWeighMultiplier = 1.00;
        private readonly List<string> _foods = new List<string>() { "Meat" };
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override double FoodWeightMultiplier => _foodWeighMultiplier;

        public override List<string> Foods => _foods;

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
