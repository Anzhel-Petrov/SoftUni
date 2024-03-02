using System;

namespace _09.ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                IPerson person = new Citizen(name, age, country);
                IResident resident = new Citizen(name, age, country);
                resident.GetName();
                person.GetName();
            }
        }
    }
}
