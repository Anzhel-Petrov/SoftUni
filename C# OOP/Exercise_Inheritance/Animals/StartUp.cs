using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input = "";
            while ((input = Console.ReadLine()) != "Beast!") 
            {
                string animalType = input;
                string[] animalProperties = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string animalName = animalProperties[0];
                int animalAge = int.Parse(animalProperties[1]);
                string animalGender = animalType != "Tomcat" ? animalProperties[2] : string.Empty;

                try
                {
                    switch (animalType)
                    {
                        case "Dog":
                            animals.Add(new Dog(animalName, animalAge, animalGender));
                            break;
                        case "Cat":
                            animals.Add(new Cat(animalName, animalAge, animalGender));
                            break;
                        case "Kitten":
                            animals.Add(new Kitten(animalName, animalAge));
                            break;
                        case "Tomcat":
                            animals.Add(new Tomcat(animalName, animalAge));
                            break;
                        case "Frog":
                            animals.Add(new Frog(animalName, animalAge, animalGender));
                            break;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
