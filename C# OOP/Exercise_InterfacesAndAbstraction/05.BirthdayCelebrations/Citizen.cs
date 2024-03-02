using _05.BirthdayCelebrations;
using System.Numerics;

namespace _04.BorderControl
{
    public class Citizen : IIdentifiable, IBirthable
    {
        public Citizen(string id, string name, int age, string birthday)
        {
            Id = id;
            Name = name;
            Age = age;
            Birthday = birthday;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthday { get; set; }
    }
}
