using System.Security.Cryptography.X509Certificates;

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Ivan");
            Student student = new Student("Dimitrichko");
            PrivateStudent privateStudent = new PrivateStudent("Filip", 115.50m);
        }

        public class Person
        {
            public Person(string name)
            {
                Name = name;
            }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class  Student : Person
        {
            public Student(string name) : base(name)
            {
                School = "47 SOU Hristo G. Danov";
            }

            public Student(string name, int age) : base(name, age)
            {
                School = "47 SOU Hristo G. Danov";
            }

            public string School { get; set; }
        }

        public class PrivateStudent : Student
        {
            public PrivateStudent(string name, decimal fee) : base(name)
            {
                Fee = fee;
            }

            public decimal Fee { get; set; }
        }
    }
}
