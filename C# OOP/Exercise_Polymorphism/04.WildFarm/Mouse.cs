using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Mouse : Mammal
    {
        private readonly double _foodWeighMultiplier = 0.10;
        private readonly List<string> _foods = new List<string>() { "Vegetable", "Fruit" };
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double FoodWeightMultiplier => _foodWeighMultiplier;

        public override List<string> Foods => _foods;

        public override void ProduceSound()
        {
            System.Console.WriteLine("Squeak"); ;
        }

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
