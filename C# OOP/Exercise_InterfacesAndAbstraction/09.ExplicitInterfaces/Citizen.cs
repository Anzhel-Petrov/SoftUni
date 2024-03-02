using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.ExplicitInterfaces
{
    internal class Citizen : IPerson, IResident
    {
        public Citizen(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        void IResident.GetName()
        {
            Console.WriteLine(Name);
        }

        void IPerson.GetName()
        {
            Console.WriteLine($"Mr/Ms/Mrs {Name}");
        }
    }
}
