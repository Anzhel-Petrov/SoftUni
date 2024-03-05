using System;
using System.Collections.Generic;
using _04.WildFarm.Factory;

namespace _04.WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();
            int line = 0;
            IAnimal animal = null;

            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                if(line % 2 == 0)
                {
                    string[] animalTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        animal = AnimalFactory.GetAnimal(animalTokens);
                        animals.Add(animal);
                        animal.ProduceSound();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    try
                    {
                        string[] foodTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        IFood food = FoodFactory.GetFood(foodTokens);
                        animal.Feed(food);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                line++;
            }

            foreach (IAnimal a in animals)
            {
                Console.WriteLine(a);
            }
        }
    }
}
