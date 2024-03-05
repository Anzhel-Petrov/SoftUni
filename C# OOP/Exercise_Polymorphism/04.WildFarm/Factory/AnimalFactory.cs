using System;

namespace _04.WildFarm.Factory
{
    public class AnimalFactory
    {
        public static IAnimal GetAnimal(string[] animalTokens)
        {
            string type = animalTokens[0];
            string name = animalTokens[1];
            double weight = double.Parse(animalTokens[2]);
            string moreInfo = animalTokens[3];

            IAnimal animal = type switch
            {
                "Cat" => new Cat(name, weight, moreInfo, animalTokens[4]),
                "Dog" => new Dog(name, weight, moreInfo),
                "Hen" => new Hen(name, weight, double.Parse(moreInfo)),
                "Mouse" => new Mouse(name, weight, moreInfo),
                "Tiger" => new Tiger(name, weight, moreInfo, animalTokens[4]),
                "Owl" => new Owl(name, weight, double.Parse(moreInfo)),
                _ => throw new ArgumentException("Invalid animal type!"),
            };

            return animal;
        }
    }
}
