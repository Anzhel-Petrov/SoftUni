using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.WildFarm.Models
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        public abstract double FoodWeightMultiplier { get; }
        public abstract List<string> Foods { get; }

        public void Feed(IFood food)
        {
            if (!Foods.Contains(food.GetType().Name))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * FoodWeightMultiplier;
            FoodEaten += food.Quantity;
        }

        public abstract void ProduceSound();

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }
    }
}
