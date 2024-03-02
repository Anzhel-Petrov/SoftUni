namespace _04.BorderControl
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
